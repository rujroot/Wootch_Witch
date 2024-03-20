using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelf :  MonoBehaviour, INteractable
{
    public Sprite sprite;
    public void Interact(GameObject player)
    {
        Inventory inventory = player.GetComponent<Inventory>();
        inventory.CreateItem(sprite, "Glass");
    }
   
}
