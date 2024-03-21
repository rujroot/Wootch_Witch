using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Broom : MonoBehaviour, IDialogueable, INteractable
{
    public bool isUse = false;

    private Camera mainCamera;
    private float screenWidth;
    private float screenHeight;
    private Rigidbody2D rb;

    void Start()
    {
        // Get the main camera
        mainCamera = Camera.main;

        // Get screen dimensions in world coordinates
        screenWidth = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x - mainCamera.ScreenToWorldPoint(Vector3.zero).x;
        screenHeight = mainCamera.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y - mainCamera.ScreenToWorldPoint(Vector3.zero).y;

        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(isUse)
        {
            Vector2 newPos = rb.position + new Vector2(1, 1) * 2.0f * Time.fixedDeltaTime;
            rb.MovePosition(newPos);
        }
        // Check if the object is within the screen bounds
        Vector3 objectPosition = transform.position;
        bool withinBounds = IsWithinScreenBounds(objectPosition);

        if (!withinBounds)
        {
            // Handle out-of-bounds cases here
        }

    }

    bool IsWithinScreenBounds(Vector3 position)
    {
        // Check if the object's position is within the screen bounds
        return position.x >= mainCamera.transform.position.x - screenWidth / 2 &&
               position.x <= mainCamera.transform.position.x + screenWidth / 2 &&
               position.y >= mainCamera.transform.position.y - screenHeight / 2 &&
               position.y <= mainCamera.transform.position.y + screenHeight / 2;
    }

    private List<string> dialogues = new List<string> { "I will try to hide it.", "Opsss!!!" };
    public void Interact(GameObject player)
    {

        if (!isUse)
        {
            isUse = true;
            
        }

    }

    public void PlayDialogue(GameObject player)
    {
        Dialogue dialogue = player.GetComponent<Dialogue>();
        dialogue.AddDialogue(dialogues, this);

    }
}
