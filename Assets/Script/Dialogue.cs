using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;

public class Dialogue : MonoBehaviour
{

    public RectTransform dialogueRect, left, right;
    public TextMeshProUGUI textUI;
    public GameObject player;

    private bool onDialogue = false;
    private List<string> allDialogues = new List<string>();
    private int index;
    private INteractable interactObject;

    public void NextDialogue()
    {
        if(index >= allDialogues.Count - 1)
        {
            // set data
            allDialogues.Clear();
            onDialogue = false;

            // clear text
            textUI.text = " ";
            Vector2 size = dialogueRect.sizeDelta;
            dialogueRect.sizeDelta = new Vector2(0, size.y);
            left.sizeDelta = new Vector2(0, 0);
            right.sizeDelta = new Vector2(0, 0);

            // last interact
            if (interactObject != null)
            {
                interactObject.Interact(player);
                interactObject = null;
            }
            
        }
        else
        {
            index++;
            ShowDialogue();
        }
        
    }

    private void ShowDialogue()
    {
        textUI.text = allDialogues[index];
        Vector2 size = dialogueRect.sizeDelta;
        float lenght = 25 * textUI.text.Length;
        lenght = math.max(300, lenght);

        left.sizeDelta = new Vector2(50, 150);
        right.sizeDelta = new Vector2(50, 150);

        left.anchoredPosition = new Vector2(-lenght / 2 ,0);
        right.anchoredPosition = new Vector2(lenght / 2, 0);
        dialogueRect.sizeDelta = new Vector2(lenght, size.y);

        
    }

    public void AddDialogue(List<string> dialogues, INteractable interactable)
    {
        foreach (string dialogue in dialogues)
        {
            allDialogues.Add(dialogue);
        }

        if(interactable != null)
        {
            this.interactObject = interactable;
        }

        if(!onDialogue)
        {
            index = 0;
            onDialogue = true;
            ShowDialogue();
        }
    }

    public bool OnDialogue()
    {
        return onDialogue;
    }

}
