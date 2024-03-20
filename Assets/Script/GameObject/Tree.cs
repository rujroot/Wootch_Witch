using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour, INteractable
{
    public Sprite glassWithTreeSprite;
    public GameObject tree;
    public void Interact(GameObject player)
    {
        Inventory inventory = player.GetComponent<Inventory>();
        GameObject glass = inventory.Find("Glass");

        if (glass != null)
        {
            inventory.Delete(glass);
            inventory.CreateItem(glassWithTreeSprite, "GlassWithTree");
        }

    }
}
