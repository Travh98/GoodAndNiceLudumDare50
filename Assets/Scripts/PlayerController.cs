using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    private PlayerControls playerControls;
    public bool alive = true;
    SpriteRenderer spriteRenderer;

    float restartTimer = 6f;
    public float timeBeforeRestart = 6.0f;

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        playerControls = new PlayerControls();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void Update()
    {
        movement = playerControls.LandControls.Move.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        if(rb)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }

        if (moveSpeed <= 0 && alive)
        {
            // Too slow and old to live
            OnDeath();
        }

        if(!alive && restartTimer > 0.0f)
        {
            restartTimer -= Time.fixedDeltaTime;
        }
        if(!alive && restartTimer <= 0.0f)
        {
            gameObject.AddComponent<PlayerDied>();
            PlayerDied restart = gameObject.GetComponent<PlayerDied>();
            restart.RestartGame();
        }

        if (spriteRenderer)
        {
            if (movement.x > 0.0f)
            {
                spriteRenderer.flipX = false;
            }
            else if(movement.x < 0.0f)
            {
                spriteRenderer.flipX = true;
            }
        }
        else
        {
            Debug.Log("Couldn't get renderer ");
        }
    }


    void OnDeath()
    {
        Destroy(rb);
        alive = false;
        restartTimer = timeBeforeRestart;
        // You dead son
    }
}
