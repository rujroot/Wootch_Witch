using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector2 movement;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Dialogue dialogue = GetComponent<Dialogue>();

        GameObject gameManager = GameObject.FindGameObjectWithTag("GameManager");
        Timer timer = gameManager.GetComponent<Timer>();


        if (!dialogue.OnDialogue() && !timer.isGameEnd())
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            movement = movement.normalized; // Prevent faster diagonal movement
        }
        else
        {
            movement = new Vector3(0f, 0f, 0f);
        }
        
    }

    void FixedUpdate()
    {
        Vector2 newPos = rb.position + movement * moveSpeed * Time.fixedDeltaTime;
        newPos.x = Mathf.Clamp(newPos.x, GetMinX(), GetMaxX());
        newPos.y = Mathf.Clamp(newPos.y, GetMinY(), GetMaxY());

        rb.MovePosition(newPos);
    }

    float GetMinX()
{
    float playerHalfWidth = GetComponent<Collider2D>().bounds.extents.x;
    // Calculate and return the minimum X boundary plus player's half width
    return Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).x + playerHalfWidth;
}

float GetMaxX()
{
    float playerHalfWidth = GetComponent<Collider2D>().bounds.extents.x;
    // Calculate and return the maximum X boundary minus player's half width
    return Camera.main.ViewportToWorldPoint(new Vector2(1, 0)).x - playerHalfWidth;
}

float GetMinY()
{
    float playerHalfHeight = GetComponent<Collider2D>().bounds.extents.y;
    // Calculate and return the minimum Y boundary plus player's half height
    return Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).y + playerHalfHeight;
}

float GetMaxY()
{
    float playerHalfHeight = GetComponent<Collider2D>().bounds.extents.y;
    // Calculate and return the maximum Y boundary minus player's half height
    return Camera.main.ViewportToWorldPoint(new Vector2(0, 1)).y - playerHalfHeight;
}
}

/*public class PlayerMovement : MonoBehaviour
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
}*/
