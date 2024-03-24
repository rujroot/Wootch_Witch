using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MagicCircleInteract :  MonoBehaviour, INteractable, IDialogueable
{
    public GameObject TopCarpet, magic, clone;
    public Animator smoke;
    public AudioSource audioSource;

    private bool firstMeet = true;

    public void Interact(GameObject player)
    {
        Inventory inventory = player.GetComponent<Inventory>();
        GameObject carpet = inventory.Find("Carpet");
        GameObject amulet = inventory.Find("Amulet");
        Timer timer = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Timer>();

        if (amulet != null)
        {
            clone.SetActive(true);
            inventory.Delete(amulet);
            timer.AddQuest("Witch");
            smoke.SetTrigger("Play");
            audioSource.Play();
        }
        else if (carpet != null)
        {
            inventory.Delete(carpet);
            TopCarpet.SetActive(true);
            Destroy(magic);
            timer.Finish("Ring");
        }

    }

    public void PlayDialogue(GameObject player)
    {
        Dialogue dialogue = player.GetComponent<Dialogue>();

        if (firstMeet)
        {
            firstMeet = false;
            dialogue.AddDialogue(new List<string>()
            {
                "The most important thing in casting spells is that only witches can use them.",
            }, null);
        }

        Inventory inventory = player.GetComponent<Inventory>();
        GameObject amulet = inventory.Find("Amulet");
        GameObject carpet = inventory.Find("Carpet");

        if (amulet != null)
        {
            dialogue.AddDialogue(new List<string>()
            {
                "Very well, my mystical artifact, reveal your power!",
            }, this);
        }
        else if(carpet != null)
        {
            dialogue.AddDialogue(new List<string>()
            {
                "It must be hidden away carefully!",
            }, this);
        }


    }

}
