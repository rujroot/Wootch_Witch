using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 30f; // Adjust this to change player speed

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Read input from WASD keys
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        // Normalize the movement vector to prevent faster diagonal movement
        movement = movement.normalized * moveSpeed * Time.deltaTime;

        // Apply movement to the Rigidbody2D
        rb.MovePosition(rb.position + movement);
    }
}
