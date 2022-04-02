using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ChasePlayer : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float stoppingDistance = 2f;
    public bool stopWhenClose = false;
    public Rigidbody2D rb;
    public GameObject target;
    Vector2 movement;

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
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
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
