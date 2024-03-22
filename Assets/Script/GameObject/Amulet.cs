using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Amulet : MonoBehaviour, INteractable, IDialogueable
{
    public Sprite amuletSprite;

    public void Interact(GameObject player)
    {
        Inventory inventory = player.GetComponent<Inventory>();
        Dialogue dialogue = player.GetComponent<Dialogue>();
        inventory.CreateItem(amuletSprite, "Amulet");
        Destroy(transform.gameObject);

    }

    public void PlayDialogue(GameObject player)
    {
        Dialogue dialogue = player.GetComponent<Dialogue>();

        dialogue.AddDialogue(new List<string>()
        {
            "The witch's artifact are meant to be used in conjunction",
            "with a magic circle!",
        },this);
        

    }
}
