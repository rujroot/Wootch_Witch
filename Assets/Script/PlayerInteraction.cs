using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject Player, Objects;
    public RectTransform rectTransform;
    public double MINDISTANCE = 3.0f;

    // Update is called once per frame
    void Update()
    {
        GameObject nearestObject = GetNearestObject();

        if (nearestObject != null)
        {
            float y = 0;

            BoxCollider2D collider = nearestObject.GetComponent<BoxCollider2D>();
            CircleCollider2D circleCollider = nearestObject.GetComponent<CircleCollider2D>();

            if(collider != null) y = collider.size.y;
            if (circleCollider != null) y = circleCollider.radius;
            
            rectTransform.anchoredPosition = nearestObject.transform.position + new Vector3(0f, 0.5f , 0f);
        }
        else
        {
            rectTransform.anchoredPosition = new Vector3(-10000.0f, -10000.0f, -10000.0f);
        }

        Dialogue dialogue = Player.GetComponent<Dialogue>();

        if (UnityEngine.Input.GetKeyDown(KeyCode.E) && nearestObject && !dialogue.OnDialogue() )
        {
            INteractable interactObj = nearestObject.GetComponent<INteractable>();
            IDialogueable dialogueable = nearestObject.GetComponent<IDialogueable>();

            if (dialogueable != null)
            {
                dialogueable.PlayDialogue(Player);
            }
            else if (interactObj != null)
            {
                interactObj.Interact(Player);
            }
        }else if (UnityEngine.Input.GetKeyDown(KeyCode.E) && dialogue.OnDialogue())
        {
            dialogue.NextDialogue();
        }else if (UnityEngine.Input.GetKeyDown(KeyCode.R))
        {
            Timer timer = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Timer>();
            timer.GameReset("Main");
        }

    }

    public GameObject GetNearestObject()
    {
        int childCount = Objects.transform.childCount;

        double nearestDistance = 2e9;
        GameObject nearestObejct = null;

        // Iterate through each child and access them
        for (int i = 0; i < childCount; i++)
        {
            // Get the child GameObject at index i
            GameObject child = Objects.transform.GetChild(i).gameObject;

            float distance = Vector3.Distance(child.transform.position, Player.transform.position);
            if(distance < nearestDistance && distance <= MINDISTANCE)
            {
                nearestDistance = distance;
                nearestObejct = child;
            }

        }

        return nearestObejct;
    }
}
