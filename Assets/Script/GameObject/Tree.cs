using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class Tree : MonoBehaviour, INteractable, IDialogueable
{
    public Sprite glassWithTreeSprite;
    public GameObject tree;
    public Animator smoke;

    public void Interact(GameObject player)
    {
        Inventory inventory = player.GetComponent<Inventory>();
        GameObject glass = inventory.Find("Glass");
        Timer timer = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Timer>();

        if (glass != null)
        {
            smoke.SetTrigger("Play");
            Destroy(transform.gameObject);
            inventory.Delete(glass);
            inventory.CreateItem(glassWithTreeSprite, "GlassWithTree");
            timer.Finish("Tree");
            
        }

    }

    public void PlayDialogue(GameObject player)
    {

        Dialogue dialogue = player.GetComponent<Dialogue>();
        dialogue.AddDialogue(new List<string> {
            "Tiny plants, perfect for fitting into bottles!" }, null);

        Inventory inventory = player.GetComponent<Inventory>();
        GameObject glass = inventory.Find("Glass");

        if(glass != null)
        {
            dialogue.AddDialogue(new List<string> {
            "The plants in bottles look absolutely adorable!" }, this);
        }

    }
}
