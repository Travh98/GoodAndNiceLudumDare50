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
    SpriteRenderer renderer;

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        playerControls = new PlayerControls();
        renderer = gameObject.GetComponent<SpriteRenderer>();
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
        if(moveSpeed <= 0)
        {
            // Too slow and old to live
            OnDeath();
        }

        if (renderer)
        {
            if (movement.x >= 0.0f)
            {
                renderer.flipX = false;
            }
            else
            {
                renderer.flipX = true;
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
        // You dead son
    }
}
