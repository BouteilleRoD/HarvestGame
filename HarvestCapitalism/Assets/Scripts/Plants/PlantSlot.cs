using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSlot : Interactable
{

    public Seed seed;
    public GameObject plant;
    State state = State.EMPTY;
    Outline outline;

    // Start is called before the first frame update
    void Start()
    {
        outline = GetComponent<Outline>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            outline.enabled = true;
            GameManager.SetInteractingObject(this);
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
        plant = Instantiate(seed.GetComponent<Seed>().growingPlant, transform.position, transform.rotation);
        plant.transform.parent = gameObject.transform;
        state = State.FULL;
        Player.inventory.Remove(seed);
    }

    public void SetSeed(Seed s)
    {
        seed = s;
    }

    public override void OnInteract()
    {
        base.OnInteract();
        GameManager.GetInventoryPanel().SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}

enum State
{
    EMPTY,
    FULL,
    RECOLTABLE
}
