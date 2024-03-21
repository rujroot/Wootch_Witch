using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;

public class Dialogue : MonoBehaviour
{

    public RectTransform dialogueRect;
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

            // clear text
            textUI.text = " ";
            Vector2 size = dialogueRect.sizeDelta;
            dialogueRect.sizeDelta = new Vector2(0, size.y);

            // last interact
            if (interactObject != null)
            {
                interactObject.Interact(player);
                interactObject = null;
            }
            
            onDialogue = false;
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
        dialogueRect.sizeDelta = new Vector2(textUI.fontSize * textUI.text.Length, size.y);
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