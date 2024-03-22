using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carpet : MonoBehaviour, INteractable, IDialogueable
{
    public Sprite carpetSprite;
    public GameObject carpet;
    public void Interact(GameObject player)
    {
        Inventory inventory = player.GetComponent<Inventory>();
        inventory.CreateItem(carpetSprite, "Carpet");
        Destroy(carpet);

    }

    public void PlayDialogue(GameObject player)
    {
        Dialogue dialogue = player.GetComponent<Dialogue>();
            dialogue.AddDialogue(new List<string> {
                "The rug can be used to cover the floor." }, this);
    }
}
