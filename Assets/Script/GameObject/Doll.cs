using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Doll : MonoBehaviour, INteractable
{
    public List<Vector3> warps;
    
    private int current = 0;
    private List<string> dialogues = new List<string> { "A petite witch doll,", "very much like \"Wootch Journey, The Witch,\" indeed!", "Where does it go?" };
    public void Interact(GameObject player)
    {
        current = current + 1;
        if(current >= warps.Count) {
            current = 0;        
        }
        transform.localPosition = warps[current];
        
        Dialogue dialogue = player.GetComponent<Dialogue>();
        dialogue.AddDialogue(dialogues, null);

    }

}
