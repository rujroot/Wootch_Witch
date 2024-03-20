using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelf :  MonoBehaviour, INteractable
{
    public Sprite sprite;
    public bool isGet = false;
    public void Interact(GameObject player)
    {
        if (!isGet)
        {
            isGet = true;
            Inventory inventory = player.GetComponent<Inventory>();
            inventory.CreateItem(sprite, "Glass");
        }
        
    }
   
}
