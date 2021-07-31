using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton

    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }
    #endregion

    public delegate void OnItemsChanged();
    public OnItemsChanged onItemsChangedCallBack;

    public List<Item> items = new List<Item>();
    public int space = 20;
    
    public bool Add(Item item)
    {
        if(items.Count >= space) 
        { 
            return false;//TODO Ouvrir un dialogue avec écrit inventaire plein
        }
        items.Add(item);
        if (onItemsChangedCallBack != null)
        {
            onItemsChangedCallBack.Invoke();
        }
        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        if (onItemsChangedCallBack != null)
        {
            onItemsChangedCallBack.Invoke();
        }
    }
    
}
