using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSlot : MonoBehaviour
{

    GameObject Plant;

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
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            outline.enabled = false;
            other.GetComponent<Player>().InteractingObject = gameObject;
        }
    }
}
