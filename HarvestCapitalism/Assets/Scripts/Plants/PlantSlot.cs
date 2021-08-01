using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSlot : Interactable
{

    public Seed seed;
    public GameObject plantObject;
    public Plant plant;
    State state = State.EMPTY;
    Outline outline;

    // Start is called before the first frame update
    void Start()
    {
        outline = GetComponent<Outline>();
        State state = State.EMPTY;
    }

    // Update is called once per frame
    void Update()
    {
        if(state == State.FULL)
        {
            if (plant.recoltable)
            {
                state = State.RECOLTABLE;
            }
            if(plantObject == null)
            {
                state = State.EMPTY;
            }
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameManager.GetInteractingObject() == null)
            {
                outline.enabled = true;
                GameManager.SetInteractingObject(this);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            outline.enabled = false;
            if (GameManager.GetInteractingObject() == this)
            {
                GameManager.SetInteractingObject(null);
            }
            GameManager.GetInventoryPanel().SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void PlantingSeed()
    {
        if (state == State.EMPTY)
        {
            plantObject = Instantiate(seed.growingPlant, transform.position, transform.rotation);
            plantObject.transform.parent = gameObject.transform;
            plant = plantObject.GetComponent<Plant>();
            GameManager.AddPlant(plant);
            state = State.FULL;
            Player.inventory.Remove(seed);
        }
    }

    public void SetSeed(Seed s)
    {
        seed = s;
    }

    public override void OnInteract()
    {
        base.OnInteract();
        Debug.Log("State : " + state);
        switch (state) {
            case State.EMPTY:
            GameManager.GetInventoryPanel().SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
                break;
            case State.FULL:
                //TODO Afficher un pop up du type "growing state (x/3)"
                break;
            case State.RECOLTABLE:
                GameManager.GatherFruit(plant);
                plant.recolted = true;
                Destroy(plantObject);
                state = State.EMPTY;
                break;
        }
    }
}

enum State
{
    EMPTY,
    FULL,
    RECOLTABLE
}
