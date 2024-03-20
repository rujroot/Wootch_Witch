using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, INteractable
{
    public GameObject warpPoint;
    public GameObject camaraPoint;
    public void Interact(GameObject player)
    {
        Inventory inventory = player.GetComponent<Inventory>();
        GameObject key = inventory.Find("Key");

        if (key != null)
        {
            Camera mainCamera = Camera.main;
            mainCamera.transform.localPosition = camaraPoint.transform.localPosition;
            player.transform.localPosition = warpPoint.transform.localPosition;
        }

    }

}
