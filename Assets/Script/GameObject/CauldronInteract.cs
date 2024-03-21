using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauldronInteract :  MonoBehaviour, INteractable
{
    public Sprite potionSprite;

    public void Interact(GameObject player)
    {
        Inventory inventory = player.GetComponent<Inventory>();
        GameObject glass = inventory.Find("Glass");

        Timer timer = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Timer>();
        if (glass != null)
        {
            inventory.Delete(glass);
            inventory.CreateItem(potionSprite, "Potion");

            timer.Finish("Cauldron");
        }
    }
   
}
