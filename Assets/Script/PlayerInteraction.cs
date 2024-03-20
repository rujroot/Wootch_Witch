using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject Player, Objects;
    public RectTransform rectTransform;
    public double MINDISTANCE = 2.0f;

    // Update is called once per frame
    void Update()
    {
        GameObject nearestObject = GetNearestObject();

        if (nearestObject != null)
        {
            rectTransform.anchoredPosition = nearestObject.transform.position + new Vector3(0, nearestObject.transform.localScale.y, 0);
        }
        else
        {
            rectTransform.anchoredPosition = new Vector3(-10000.0f, -10000.0f, -10000.0f);
        }

        if (UnityEngine.Input.GetKeyDown(KeyCode.E) && nearestObject)
        {
            print(nearestObject);
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
