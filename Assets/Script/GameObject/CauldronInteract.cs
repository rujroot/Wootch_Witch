using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CauldronInteract :  MonoBehaviour, INteractable, IDialogueable
{
    public Sprite potionSprite;
    public Animator boomAnimator, cauldron, smoke;
    public List<AudioClip> clips;
    public AudioSource audioSource;

    private bool isEmpty = false;
    private bool firstMeet = true;
    public void Interact(GameObject player)
    {
        Inventory inventory = player.GetComponent<Inventory>();
        Dialogue dialogue = player.GetComponent<Dialogue>();
        GameObject glass = inventory.Find("Glass");
        GameObject book = inventory.Find("Book");

        Timer timer = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Timer>();
        if(book != null && !isEmpty)
        {
            isEmpty = true;
            boomAnimator.SetTrigger("Boom");
            cauldron.SetTrigger("Empty");
            dialogue.AddDialogue(new List<string>() { "Opss!", "I shouldn't trust this book." }, null);
            timer.Finish("Cauldron");
        }
        else if (glass != null && !isEmpty)
        {
            isEmpty = true;
            inventory.Delete(glass);
            inventory.CreateItem(potionSprite, "Potion");
            cauldron.SetTrigger("Empty");
            smoke.SetTrigger("Play");
            timer.Finish("Cauldron");

            audioSource.clip = clips[1];
            audioSource.Play();
        }
    }

    public void PlayDialogue(GameObject player)
    {
        Dialogue dialogue = player.GetComponent<Dialogue>();
        
        if(firstMeet)
        {
            firstMeet = false;
            dialogue.AddDialogue(new List<string>()
            {
                "In a massive, common cauldron, magic potions are often brewed.",
                "Villagers usually repurpose it to collect rainwater.",
            } , null);
            audioSource.clip = clips[0];
            audioSource.Play();
        }

        Inventory inventory = player.GetComponent<Inventory>();
        GameObject glass = inventory.Find("Glass");
        GameObject book = inventory.Find("Book");

        if (isEmpty)
        {
            dialogue.AddDialogue(new List<string>()
            {
                "It's empty."
            }, null);
        }
        else if(book != null)
        {
            dialogue.AddDialogue(new List<string>()
            {
                "Sugar, fish sauce, and oyster sauce...",
                "Sounds like a recipe for a magical feast!",
            }, this);

        }
        else if (glass != null)
        {
            dialogue.AddDialogue(new List<string>()
            {
                "Pour the enchanted potion into a bottle!"
            }, this);
        }

    }

}
