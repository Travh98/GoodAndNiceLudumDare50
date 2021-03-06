using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ChasePlayer : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float stoppingDistance = 2f;
    public bool stopWhenClose = false;
    public Rigidbody2D rb;
    public GameObject target;
    Vector2 movement;
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(target != null)
        {
            float distance = (target.gameObject.transform.position -
                gameObject.transform.position).magnitude;

            if (stopWhenClose && distance <= stoppingDistance)
            {
                movement = Vector2.zero;
            }
            else
            {
                movement = (target.gameObject.transform.position -
                    gameObject.transform.position).normalized;
            }
        }
        if(spriteRenderer)
        {
            if(movement.x >= -0.1f)
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
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
