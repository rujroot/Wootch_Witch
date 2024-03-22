using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, INteractable, IDialogueable
{
    public GameObject warpPoint;
    public GameObject camaraPoint;

    public bool firstMeet = true, firstMeetKey = true;
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
        else
        {
            Dialogue dialogue = player.GetComponent<Dialogue>();
            dialogue.AddDialogue(new List<string>()
            {
                "It's lock."
            }, null);
        }

    }

    public void PlayDialogue(GameObject player)
    {
        Dialogue dialogue = player.GetComponent<Dialogue>();

        Inventory inventory = player.GetComponent<Inventory>();
        GameObject key = inventory.Find("Key");

        if (firstMeet) 
        {
            firstMeet = false;
           dialogue.AddDialogue(new List<string>()
            {
                "The door to the back of the house!"
            }, this);

            
        }

        if(key != null && firstMeetKey)
        {
            firstMeetKey = false;
            dialogue.AddDialogue(new List<string>()
            {
                "From now on, there shall be a backyard!"
            }, this);
        }
        else
        {
            Interact(player);
        }

    }

}
