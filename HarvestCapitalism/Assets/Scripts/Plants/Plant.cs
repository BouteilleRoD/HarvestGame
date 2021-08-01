using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{

    public float HP = 100f;
    public bool recoltable = false;
    public bool recolted = false;
    public bool isAlive = true;
    int growingState = 0;
    public int growingDuration = 1;
    public int enemyNumber = 1;
    public int price = 10;
    public Item fruit;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(HP <= 0 && isAlive)
        {
            isAlive = false;
            GameManager.UpdatePlants();
        }
    }

    public void CheckRecoltable() 
    {
        if(growingState >= growingDuration)
        {
            recoltable = true;
        }
    }
    public void Growing()
    {
        if (!recoltable)
        {
            growingState++;
            if (growingState == growingDuration) 
            {
                transform.localScale = transform.localScale * 5f;
            }
            CheckRecoltable();
        }
    }
}
