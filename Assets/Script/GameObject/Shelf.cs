using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shelf :  MonoBehaviour, INteractable, IDialogueable
{
    public Sprite sprite;
    public GameObject bottle;

    private bool firstMeet = true;

    public void Interact(GameObject player)
    {
        Dialogue dialogue = player.GetComponent<Dialogue>();

        if (firstMeet)
        {
            firstMeet = false;
            Inventory inventory = player.GetComponent<Inventory>();
            inventory.CreateItem(sprite, "Glass");
            Destroy(bottle);
        }
        
    }

    public void PlayDialogue(GameObject player)
    {

        Dialogue dialogue = player.GetComponent<Dialogue>();
        if(firstMeet)
        {
            dialogue.AddDialogue(new List<string> { 
                "A vessel meant for holding a witch's potion,", 
                "but with its beautiful design,", 
                "some villagers use it as a planter for their plants." }, this);
        }
        else
        {
            dialogue.AddDialogue(new List<string> {
                "It's empty." }, this);
        }
        


    }

}
