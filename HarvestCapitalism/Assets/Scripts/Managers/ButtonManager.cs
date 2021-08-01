using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    }

    #endregion

    public GameManager gameManager;
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
                GameManager.UpdateMoney();
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

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Play()
    {
        SceneManager.LoadScene(1); 
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
