using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool alive = true, onGround;
    GameManager gameManager;
    AudioSource audioSource;
    public AudioClip pisada;
    public Animator anim;
    private Rigidbody2D rb;
    float animSpeed, gravidade;
    Vector2 velocidade;
    // Start is called before the first frame update
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim.Play("Idle");
    }

    // Update is called once per frame
    void Update()
    {
        if (alive)
        {
            if (Input.GetKeyDown(KeyCode.Space) && gameManager.GetPlay())
            {
                SwitchSide();
            }
        }        
    }
    public void SwitchSide()
    {
        if (onGround)
        {
            rb.velocity = new Vector2(0, 20 * rb.gravityScale);
            rb.gravityScale *= -1;
            if (transform.localScale.y > 0) anim.Play("Switch_Side");
            else anim.Play("Switch_Side2");
            onGround = false;
        }        
    }

    public void InvertY()
    {
        if (rb.gravityScale > 0) transform.localScale = new Vector3(-1, 1, 1);
        else transform.localScale = new Vector3(-1, -1, 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Tool"))
        {
            gameManager.AddPoints(20);
            collision.gameObject.GetComponent<Tool>().PlaySound();
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        onGround = true;
        if (collision.gameObject.CompareTag("Plataforma") && alive)
        {
            if (gameManager.GetSpeed() > 30f) anim.Play("Naruto_run");
            else if (gameManager.GetSpeed() == 0) anim.Play("Idle");
            else anim.Play("corrida");
            Pisada();
        }

        if (collision.gameObject.layer == 7 && alive)
        {
            Death();
            alive = false;
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    void Death()
    {
        if (transform.localScale.y > 0) anim.Play("Death");
        else
        {
            anim.Play("Death_invertido");
            anim.speed = 1;
        }
        rb.gravityScale = 2;
        rb.velocity = Vector2.zero;
        gameManager.Death();
        alive = false;
    }

    public void AdjustSpeed()
    {
        anim.speed += 0.01f;
        if (rb.gravityScale > 0) rb.gravityScale += 0.01f;
        else rb.gravityScale -= 0.01f;
    }

    public void Play()
    {
        anim.Play("corrida");
    }

    public void Pause()
    {
        animSpeed = anim.speed;
        anim.speed = 0;
        velocidade = rb.velocity;
        rb.velocity = Vector2.zero;
        gravidade = rb.gravityScale;
        rb.gravityScale = 0;
    }

    public void Resume()
    {
        anim.speed = animSpeed;
        rb.velocity = velocidade;
        rb.gravityScale = gravidade;
    }

    public void Restart()
    {
        anim.speed = 1;
        anim.Play("Idle");
        rb.gravityScale = 1;
        alive = true;
        transform.localScale = new Vector3(-1, 1, 1);
    }

    public void Pisada()
    {
        audioSource.clip = pisada;
        audioSource.Play();
    }
}
