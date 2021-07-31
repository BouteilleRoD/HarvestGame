using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : Item
{
    public GameObject growingPlant;

    public Sprite sprite;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Use()
    {
        base.Use();
        GameManager.GetInteractingObject().GetComponent<PlantSlot>().SetSeed(this);
        GameManager.GetInteractingObject().GetComponent<PlantSlot>().PlantingSeed();
    }
}
