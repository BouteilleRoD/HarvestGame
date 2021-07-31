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
    [SerializeField] private LightingManager LM;
    [SerializeField] private static List<Plant> Plants = new List<Plant>();

    private static int Money = 100;
    public int DayCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        inventoryPanel = GameObject.Find("InventoryPanel");
        inventoryPanel.SetActive(false);
        marketPanel = GameObject.Find("MarketPanel");
        marketPanel.SetActive(false);
        LM.TimeOfDay = 36f;
    }

    // Update is called once per frame
    void Update()
    {
        if (LM.TimeOfDay >= 37.5f - Time.deltaTime && LM.TimeOfDay <= 37.5f)
        {
            DayCount++;
            Debug.Log("Daycount ++");
            UpdatePlants();
            foreach (Plant p in Plants)
            {
                if (p.recolted)
                {
                    RemovePlant(p);
                }
                p.Growing();
            }
        }
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

    public static void AddPlant(Plant p)
    {
        Plants.Add(p);
    }

    public static void RemovePlant(Plant p)
    {
        Plants.Remove(p);
    }
    public static void GatherFruit(Plant p)
    {
        if (p.isAlive)
        {
            if(Player.inventory.Add(p.fruit)) UpdatePlants();
        }
    }

    public static void UpdatePlants()
    {
        for(int i = 0; i < Plants.Count; i++)
        {
            if (!Plants[i].isAlive)
            {
                Destroy(Plants[i].gameObject);
                RemovePlant(Plants[i]);
            }
        }
    }
}
