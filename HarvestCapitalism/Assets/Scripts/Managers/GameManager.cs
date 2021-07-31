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
    [SerializeField] public static GameObject interactingObject;
    [SerializeField] private static GameObject marketPanel;


    public static Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        inventoryPanel = GameObject.Find("InventoryPanel");
        inventoryPanel.SetActive(false);
        marketPanel = GameObject.Find("MarketPanel");
        //marketPanel.SetActive(false);
        inventory = Inventory.instance;
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
    public static GameObject GetInteractingObject()
    {
        return interactingObject;
    }

    #endregion

    #region Setters
    public static void SetCurrentPanel(GameObject o)
    {
        currentPanel = o;
    }
    public static void SetInteractingObject(GameObject o)
    {
        interactingObject = o;
    }
    #endregion
}
