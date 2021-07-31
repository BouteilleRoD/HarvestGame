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

    GameManager GM;
    // Start is called before the first frame update
    void Start()
    {
        GM = GameManager.instance;
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
        GameManager.inventory.Add(i);
        //TODO retirer la monaie
    }

    public void SellItem(Item i)
    {
        GameManager.inventory.Remove(i);
        //TODO ajouter la monaie
    }
}
