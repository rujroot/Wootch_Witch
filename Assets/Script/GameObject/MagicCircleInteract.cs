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
        Timer timer = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Timer>();

        if (carpet != null)
        {
            inventory.Delete(carpet);
            TopCarpet.SetActive(true);
            Destroy(magic);
            timer.Finish("Ring");
        }

    }
   
}
