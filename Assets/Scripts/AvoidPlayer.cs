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

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
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
