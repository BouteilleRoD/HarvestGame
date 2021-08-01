using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : Item
{

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
        if (GameManager.GetInteractingObject() is Market)
        {
            SellItem(this);
        }else
        {
            Debug.Log("Go to the market to sell");
        }
    }

    public void SellItem(Item i)
    {
        GameManager.AddMoney(i.price);
        GameManager.UpdateMoney();
        Player.inventory.Remove(i);
        Debug.Log("Money = " + GameManager.GetMoney());
    }
}
