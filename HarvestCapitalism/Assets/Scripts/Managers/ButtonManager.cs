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
        AudioManager.instance.PlaySFX("sfx_button");
    }

    public void CloseInventory()
    {
        GameManager.GetInventoryPanel().SetActive(false);
        AudioManager.instance.PlaySFX("sfx_button");
    }

    public void BuyItem(Item i)
    {
        AudioManager.instance.PlaySFX("sfx_button");
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

        AudioManager.instance.PlaySFX("sfx_button");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Play()
    {

        AudioManager.instance.PlaySFX("sfx_button");
        SceneManager.LoadScene(1); 
    }

    public void MainMenu()
    {

        AudioManager.instance.PlaySFX("sfx_button");
        AudioManager.instance.PlayMusic("menuMusic");
        SceneManager.LoadScene(0);
    }

    public void OpenPanel(GameObject o)
    {
        AudioManager.instance.PlaySFX("sfx_button");
        o.SetActive(true);
    }

    public void CloseMenu(GameObject o)
    {
        AudioManager.instance.PlaySFX("sfx_button");
        o.SetActive(false);
    }

    public void Quit()
    {

        AudioManager.instance.PlaySFX("sfx_button");
        Application.Quit();
    }

}
