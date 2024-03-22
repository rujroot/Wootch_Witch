using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackCatInteract :  MonoBehaviour, INteractable, IDialogueable
{
    public Sprite keySprite;
    public Sprite glassSprite;
    public GameObject cat;


    private bool firstMeet = true;
    public void Interact(GameObject player)
    {
        Inventory inventory = player.GetComponent<Inventory>();
        Dialogue dialogue = player.GetComponent<Dialogue>();
        GameObject potion = inventory.Find("Potion");
        Timer timer = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Timer>();

        if (potion != null)
        {

            inventory.Delete(potion);
            inventory.CreateItem(keySprite, "Key");
            inventory.CreateItem(glassSprite, "Glass");

            dialogue.AddDialogue(new List<string>() { "This key might just unlock the door!" }, null);
        }
        else
        {
            Destroy(cat);
            timer.Finish("Cat");

        }

    }

    public void PlayDialogue(GameObject player)
    {
        Dialogue dialogue = player.GetComponent<Dialogue>();

        if(firstMeet)
        {
            firstMeet = false;
            dialogue.AddDialogue(new List<string>() { 
                "There's a little four-legged black critter,", 
                "singing merrily, and guess what?",
                "Rumor has it, it's the pet of a witch!"
            }, null);
        }

        Inventory inventory = player.GetComponent<Inventory>();
        GameObject potion = inventory.Find("Potion");

        if (potion != null)
        {

            dialogue.AddDialogue(new List<string>() {
                "Little cat, would you like to try it?"
            }, this);

        }
        else
        {
            dialogue.AddDialogue(new List<string>() {
                "Abracadabra, vanish you shall,",
                "Into the mist, beyond recall.",
                "People's eyes will search in vain,",
                "For you've slipped away, like drops of."
            }, this);

        }

    }


}
