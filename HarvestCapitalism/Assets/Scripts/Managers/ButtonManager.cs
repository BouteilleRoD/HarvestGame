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
        if (AudioManager.instance) 
        {
            AudioManager.instance.PlaySFX("sfx_button");
        }
    }

    public void CloseInventory()
    {
        GameManager.GetInventoryPanel().SetActive(false);
        if (AudioManager.instance) 
        {
            AudioManager.instance.PlaySFX("sfx_button");
        }
    }

    public void BuyItem(Item i)
    {
        if (AudioManager.instance) 
        {
            AudioManager.instance.PlaySFX("sfx_button");
        }
        if (GameManager.GetMoney() > i.price && GameManager.GetMoney() - i.price >= GameManager.GetRent())
        {
            if (Player.inventory.Add(i))
            {
            
                GameManager.AddMoney(-i.price);
                GameManager.UpdateMoney();
            }
            else
            {
                //TODO pop up
            }
        }
        else
        {
            //TODO pop up
            Debug.Log("Not enough money !");
        }
    }

    public void Restart()
    {
        if (AudioManager.instance) 
        {
            AudioManager.instance.PlaySFX("sfx_button");
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Play()
    {
        if (AudioManager.instance) 
        {
            AudioManager.instance.PlaySFX("sfx_button");
        }
        SceneManager.LoadScene(1); 
    }

    public void MainMenu()
    {
        if (AudioManager.instance) 
        {
            AudioManager.instance.PlaySFX("sfx_button");
            AudioManager.instance.PlayMusic("menuMusic");
        }
        if (GameManager.GetisPaused())
        {
            gameManager.Resume();
        }
        SceneManager.LoadScene(0);
    }

    public void OpenPanel(GameObject o)
    {
        if (AudioManager.instance) 
        {
            AudioManager.instance.PlaySFX("sfx_button");
        }
        o.SetActive(true);
    }

    public void CloseMenu(GameObject o)
    {
        if (AudioManager.instance) 
        {
            AudioManager.instance.PlaySFX("sfx_button");
        }
        o.SetActive(false);
    }

    public void Quit()
    {
        if (AudioManager.instance) 
        {
            AudioManager.instance.PlaySFX("sfx_button");
        }
        Application.Quit();
    }

}
