using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    #region Singleton

    public static ButtonManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    #endregion


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseCurrentPanel()
    {
        GameManager.GetCurrentPanel().SetActive(false);
    }

    public void CloseInventory()
    {
        GameManager.GetInventoryPanel().SetActive(false);
    }

    public void BuyItem(Item i)
    {
        if (Player.inventory.Add(i))
        {
            if (GameManager.GetMoney() > i.price)
            {
                GameManager.AddMoney(-i.price);
                Debug.Log("Item bought !");
            }
            else
            {
                Debug.Log("Not enough money !");
            }
        }
        else
        {
            //TODO pop up
        }
    }

    
}
