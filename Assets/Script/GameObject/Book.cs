using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour, INteractable, IDialogueable
{
    public Sprite sprite;


    private List<string> dialogues = new List<string> { "This is a book." };
    public void Interact(GameObject player)
    {

        Inventory inventory = player.GetComponent<Inventory>();
        inventory.CreateItem(sprite, "Book");
        Destroy(transform.gameObject);

    }

    public void PlayDialogue(GameObject player)
    {
        Dialogue dialogue = player.GetComponent<Dialogue>();
        dialogue.AddDialogue(new List<string> { "Reading books about chemistry can give you knowledge about pharmaceutical preparation!", "This knowledge might come in handy at the cauldron!" }, this);
    }

}
