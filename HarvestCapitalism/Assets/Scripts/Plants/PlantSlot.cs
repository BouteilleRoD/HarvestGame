using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSlot : MonoBehaviour
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
            GameManager.SetInteractingObject(gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            outline.enabled = false;
            if (GameManager.GetInteractingObject() == gameObject)
            {
                GameManager.SetInteractingObject(null);
            }
        }
    }

    public void PlantingSeed()
    {
        plant = Instantiate(seed.GetComponent<Seed>().growingPlant, transform.position, transform.rotation);
        plant.transform.parent = gameObject.transform;
        state = State.FULL;
        GameManager.inventory.Remove(seed);
    }

    public void SetSeed(Seed s)
    {
        seed = s;
    }
}

enum State
{
    EMPTY,
    FULL,
    RECOLTABLE
}
