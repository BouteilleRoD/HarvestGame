using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemType type;
    public int price;

    public GameObject usingPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Use()
    {
        Debug.Log("Using the item " + gameObject.name);
    }

}

public enum ItemType
{
    SEED,
    FRUIT
}
