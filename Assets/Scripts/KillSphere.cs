using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class KillSphere : MonoBehaviour
{
    public LayerMask targetLayer;
    public float radius = 2f;
    public int damage = 1;

    void Start()
    {
        transform.localScale = new Vector3(transform.localScale.x * radius, 
            transform.localScale.y * radius, transform.localScale.z);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((targetLayer.value & (1 << collision.gameObject.layer)) > 0)
        {
            if(collision.gameObject.GetComponent<Health>())
            {
                collision.gameObject.GetComponent<Health>().takeDamage(damage);
            }
        }
    }
}
