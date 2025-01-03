using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 1f;
    public Animator animator;
    public AudioSource audioSource;

    private Vector2 movement;
    private Rigidbody2D rb;
    private bool walking = false;

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

            if(!( (movement.x > -1 && movement.x < 1) || (movement.y > -1 && movement.y < 1) ) )
            {
                if (movement.x > 0) movement.x = 1;
                else movement.x = -1;
                movement.y = 0;
            }

            animator.SetFloat("x", movement.x);
            animator.SetFloat("y", movement.y);
   
        }
        else
        {
            movement = new Vector3(0f, 0f, 0f);
           
        }
        
    }

    void FixedUpdate()
    {
        Vector2 newPos = rb.position + movement * moveSpeed * Time.fixedDeltaTime;
        float speed = (movement * moveSpeed * Time.fixedDeltaTime).magnitude;
        animator.SetFloat("speed",  speed);
        newPos.x = Mathf.Clamp(newPos.x, GetMinX(), GetMaxX());
        newPos.y = Mathf.Clamp(newPos.y, GetMinY(), GetMaxY());

        if(speed != 0)
        {
            if(!walking) audioSource.Play();
            walking = true;
        }
        else
        {
            audioSource.Stop();
            walking= false;
        }

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
