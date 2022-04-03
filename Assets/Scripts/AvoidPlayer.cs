using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidPlayer : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float farEnoughDistance = 10f;
    public Rigidbody2D rb;
    public GameObject target;
    Vector2 movement = Vector2.zero;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (target != null)
        {
            float distance = (target.gameObject.transform.position -
                gameObject.transform.position).magnitude;

            if (distance >= farEnoughDistance)
            {
                movement = Vector2.zero;
            }
            else
            {
                movement = -(target.gameObject.transform.position -
                    gameObject.transform.position).normalized;
            }
        }

        if (spriteRenderer)
        {
            if (movement.x >= -0.1f)
            {
                spriteRenderer.flipX = false;
            }
            else
            {
                spriteRenderer.flipX = true;
            }
        }
        else
        {
            Debug.Log("Couldn't get renderer ");
        }
    }

    void FixedUpdate()
    {
        if(rb)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }

    public void Freeze()
    {
        moveSpeed = 0;
        rb.velocity = Vector2.zero;
        Destroy(rb);
    }
}
