using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Doll : MonoBehaviour, INteractable
{
    public List<Vector3> warps;
    public Sprite glassWithDollSprite;
    public AudioSource audioSource;

    private int current = 0;
    private List<string> dialogues = new List<string> { "A petite witch doll,", "very much like \"Wootch Journey, The Witch,\" indeed!", "Where does it go?" };
    public void Interact(GameObject player)
    {
        Inventory inventory = player.GetComponent<Inventory>();
        GameObject glass = inventory.Find("Glass");
        Timer timer = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Timer>();

        if (glass != null)
        {
            Dialogue dialogue = player.GetComponent<Dialogue>();
            dialogue.AddDialogue(new List<string> { "Gotcha!" }, null);

            Destroy(transform.gameObject);
            inventory.Delete(glass);
            inventory.CreateItem(glassWithDollSprite, "GlassWithDoll");
            timer.Finish("Tree");
            

        }
        else
        {
            current = current + 1;
            if(current >= warps.Count) {
                current = 0;        
            }
            transform.localPosition = warps[current];
        
            Dialogue dialogue = player.GetComponent<Dialogue>();
            dialogue.AddDialogue(dialogues, null);
            audioSource.Play();
        }

        

    }

}
