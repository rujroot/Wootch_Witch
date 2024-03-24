using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Broom : MonoBehaviour, IDialogueable, INteractable
{
    public bool isUse = false;
    public GameObject cat, player;
    public Animator smoke;
    public AudioSource audioSource;

    private Vector2 dir = new Vector2(-1, 0);
    private float speed = 60.0f;
    private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(isUse)
        {
            Vector2 newPos = rb.position + dir * speed * Time.deltaTime;
            rb.MovePosition(newPos);


            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0, 0, angle + 270);
        }

    }

    IEnumerator RanddomBroom()
    {
        
        for(int i = 0; i < 3; ++i)
        {
            yield return new WaitForSeconds(0.5f);
            if(i == 1)
            {
                dir = new Vector2(1, 1);
            }
            else if(i == 2)
            {
                dir = new Vector2(0, -1);
            }
        }

        yield return new WaitForSeconds(0.5f);

        if (cat != null)
        {
            Vector2 catPos = new Vector2(cat.transform.position.x, cat.transform.position.y);
            Vector2 broomPos = new Vector2(transform.position.x, transform.position.y);

            dir = (catPos - broomPos).normalized;
        }

        yield return new WaitForSeconds(0.5f);

        dir = -dir;

    }

    IEnumerator MakeDestory()
    {
        yield return new WaitForSeconds(2f);
        Destroy(cat);
        Destroy(transform.gameObject);

    }

    private List<string> dialogues = new List<string> { "I will try to hide it.", "Opsss!!!" };
    public void Interact(GameObject player)
    {

        if (!isUse)
        {
            isUse = true;
            GetComponent<BoxCollider2D>().isTrigger = true;
            rb = transform.gameObject.AddComponent<Rigidbody2D>();
            rb.gravityScale = 0;
            
            StartCoroutine(RanddomBroom());
            audioSource.Play();
        }

    }

    public void PlayDialogue(GameObject player)
    {
        Dialogue dialogue = player.GetComponent<Dialogue>();
        if (!isUse)
        {
            smoke.SetTrigger("Play");
            dialogue.AddDialogue(new List<string> { "The magical flying apparatus, repurposed by villagers for floor cleaning!" }, this);
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "BlackCat")
        {
            Dialogue dialogue = player.GetComponent<Dialogue>();
            dialogue.AddDialogue(new List<string> { "The flying broom sweeps everywhere, even colliding with cats!" }
            , null);
            Timer timer = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Timer>();
            timer.Finish("Cat");
            cat = other.gameObject;
            cat.GetComponent<Collider2D>().isTrigger = true;
            cat.transform.SetParent(transform);
            cat.transform.localPosition = Vector3.zero;
            StartCoroutine(MakeDestory());
        }
    }

}
