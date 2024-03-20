using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackCatInteract :  MonoBehaviour, INteractable
{
    public Sprite keySprite;
    public Sprite glassSprite;
    public GameObject cat;
    public void Interact(GameObject player)
    {
        Inventory inventory = player.GetComponent<Inventory>();
        GameObject potion = inventory.Find("Potion");

        if (potion != null)
        {
            inventory.Delete(potion);
            inventory.CreateItem(keySprite, "Key");
            inventory.CreateItem(glassSprite, "Glass");
        }
        else
        {
            Destroy(cat);
        }

    }
   
}
