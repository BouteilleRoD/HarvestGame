using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] private GameObject Enemy;
    [SerializeField] private static Text MoneyText;
    private static int Money = 100;
    public int DayCount = 0;
    private int numberOfEnemyToSpawn = 0;
    bool isNight = false;
    private float DayTimeIncrement = 10f;
    private int rentValue = 10;
    private int rentIncrement = 1;
    // Start is called before the first frame update
    void Start()
    {
        inventoryPanel = GameObject.Find("InventoryPanel");
        inventoryPanel.SetActive(false);
        marketPanel = GameObject.Find("MarketPanel");
        marketPanel.SetActive(false);
        LM.TimeOfDay = LightingManager.MaxTimeOfDay * 0.25f + 1;
        MoneyText = GameObject.Find("MoneyText").GetComponent<Text>();

        LM.OnNight += OnNightStart;
        LM.OnDay += OnDayStart;
        
    }

    // Update is called once per frame
    void Update()
    { 
        
    }

    private void OnNightStart()
    {
        isNight = true;
        if (isNight && numberOfEnemyToSpawn == 0)
        {
            foreach (Plant p in Plants)
            {
                numberOfEnemyToSpawn += p.enemyNumber;
            }
            StartCoroutine("StartNight");

        }
    }

    private void OnDayStart()
    {
        DayCount++;
        if(DayCount % 10 == 0)
        {
            LightingManager.MaxTimeOfDay += DayTimeIncrement;
        }
        isNight = false;
        UpdatePlants();
        foreach (Plant p in Plants)
        {
            if (p.recolted)
            {
                RemovePlant(p);
            }
            p.Growing();
        }
        PayRent();
        RentIncrease();
        numberOfEnemyToSpawn = 0;
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

    public static int GetPlantsCount()
    {
        return Plants.Count;
    }
    public static Plant GetPlant(int i)
    {
        if(Plants[i] != null)
        {
            return Plants[i];
        }
        return null;
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

    public void PayRent()
    {
        Money -= rentValue;
        UpdateMoney();
    }
    public void RentIncrease()
    {
        rentValue += rentIncrement;
    }

    public static void UpdateMoney()
    {
        MoneyText.text = "Money : " + Money;
    }
    IEnumerator StartNight()
    {
        float spawnCD = LightingManager.MaxTimeOfDay / numberOfEnemyToSpawn;
        for (int i = 0; i < numberOfEnemyToSpawn; i++)
        {
            Instantiate(Enemy);
            yield return new WaitForSeconds(spawnCD);
        }
    }
    
}
