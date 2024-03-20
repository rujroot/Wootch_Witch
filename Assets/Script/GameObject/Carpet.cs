using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carpet : MonoBehaviour, INteractable
{
    public Sprite carpetSprite;
    public GameObject carpet;
    public void Interact(GameObject player)
    {
        Inventory inventory = player.GetComponent<Inventory>();
        inventory.CreateItem(carpetSprite, "Carpet");
        Destroy(carpet);

    }
}
