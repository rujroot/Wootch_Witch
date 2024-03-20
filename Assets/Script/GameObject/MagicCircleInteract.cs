using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCircleInteract :  MonoBehaviour, INteractable
{
    public GameObject TopCarpet, magic;

    public void Interact(GameObject player)
    {
        Inventory inventory = player.GetComponent<Inventory>();
        GameObject carpet = inventory.Find("Carpet");
        print(carpet);

        if (carpet != null)
        {
            inventory.Delete(carpet);
            TopCarpet.SetActive(true);
            Destroy(magic);
        }

    }
   
}
