using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;

    Item item;
    public void AddItem(Item i)
    {
        item = i;
        icon.sprite = item.sprite;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
    }

    public void UseItem()
    {
        if(item != null)
        {
            item.Use();
            if (AudioManager.instance)
            {
                AudioManager.instance.PlaySFX("sfx_button");
            }
        }
    }
}
