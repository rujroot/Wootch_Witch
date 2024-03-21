using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelf :  MonoBehaviour, INteractable, IDialogueable
{
    public Sprite sprite;
    public bool isGet = false;

    private List<string> dialogues = new List<string> { "This is Shelf", "I found a bottle." };
    public void Interact(GameObject player)
    {
      
        if (!isGet)
        {
            isGet = true;
            Inventory inventory = player.GetComponent<Inventory>();
            inventory.CreateItem(sprite, "Glass");

            dialogues.RemoveAt(1);
        }
        
    }

    public void PlayDialogue(GameObject player)
    {
        Dialogue dialogue = player.GetComponent<Dialogue>();
        dialogue.AddDialogue(dialogues, this);


    }

}
