using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Market : Interactable
{
    Outline outline;

    GameObject sub;
    // Start is called before the first frame update
    void Start()
    {
        outline = GetComponent<Outline>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            outline.enabled = true;
            GameManager.SetInteractingObject(this);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            outline.enabled = false;
            if (GameManager.GetMarketPanel().activeSelf)
            {
                if (sub = GameObject.FindGameObjectWithTag("SubPanel"))
                {
                    sub.SetActive(false);
                    sub = null;
                }
                if (GameManager.GetInventoryPanel().activeSelf)
                {
                    GameManager.GetInventoryPanel().SetActive(false);
                }
                GameManager.GetMarketPanel().SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            if (GameManager.GetInteractingObject() == this)
            {
                GameManager.SetInteractingObject(null);
            }

        }
    }

    public override void OnInteract()
    {
        base.OnInteract();
        GameManager.GetMarketPanel().SetActive(true);
        GameManager.GetInventoryPanel().SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
