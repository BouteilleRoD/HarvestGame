using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton

    public static GameManager instance;

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

    [SerializeField] private static GameObject inventoryPanel;
    [SerializeField] private static GameObject currentPanel;
    [SerializeField] public static Interactable interactingObject;
    [SerializeField] private static GameObject marketPanel;

    private static int Money = 100;
    // Start is called before the first frame update
    void Start()
    {
        inventoryPanel = GameObject.Find("InventoryPanel");
        inventoryPanel.SetActive(false);
        marketPanel = GameObject.Find("MarketPanel");
        marketPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #region Getters
    public static GameObject GetInventoryPanel()
    {
        return inventoryPanel;
    }

    public static GameObject GetCurrentPanel()
    {
        return currentPanel;
    }
    public static GameObject GetMarketPanel()
    {
        return marketPanel;
    }
    public static Interactable GetInteractingObject()
    {
        return interactingObject;
    }

    public static int GetMoney()
    {
        return Money;
    }

    #endregion

    #region Setters
    public static void SetCurrentPanel(GameObject o)
    {
        currentPanel = o;
    }
    public static void SetInteractingObject(Interactable o)
    {
        interactingObject = o;
    }
    public static void AddMoney(int i)
    {
        Money += i;
    }
    #endregion
}
