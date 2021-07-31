using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    bool recoltable = false;
    int growingState = 0;
    int growingDuration = 1;
    int price = 10;

    public Sprite sprite;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckRecoltable() 
    {
        if(growingState == growingDuration)
        {
            recoltable = true;
        }
    }
    public void Growing()
    {
        growingState++;
        transform.localScale = transform.localScale * 5f;
    }
}
