using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketSlot : MonoBehaviour
{
    public GameObject sellingPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenPanel()
    {
        sellingPanel.SetActive(true);
        GameManager.SetCurrentPanel(sellingPanel);
    }
}
