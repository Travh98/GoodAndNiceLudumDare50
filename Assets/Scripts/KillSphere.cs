using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class KillSphere : MonoBehaviour
{
    public GameObject parent;
    public LayerMask targetLayer;
    public float radius = 2f;
    public int damage = 1;
    public float damageToPlayerAge = 0.25f;

    public float cooldownTime = 0.5f;  // Seconds before able to attack again
    private float cooldownTimer = 0f;

    void Start()
    {
        if(parent == null)
        {
            Debug.Log("Killsphere has no parent, sad!");
        }
        transform.localScale = new Vector3(transform.localScale.x * radius, 
            transform.localScale.y * radius, transform.localScale.z);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(cooldownTimer > 0f)
        {
            return;  // Not cooled down, don't do anything
        }

        if ((targetLayer.value & (1 << collision.gameObject.layer)) > 0)
        {
            if(collision.gameObject.GetComponent<Health>())
            {
                collision.gameObject.GetComponent<Health>().takeDamage(damage, parent);
                cooldownTimer = cooldownTime;
            }
            if(collision.gameObject.GetComponent<PlayerController>())
            {
                if(collision.gameObject.GetComponent<PlayerController>().alive)
                {
                    collision.gameObject
                        .GetComponent<PlayerController>().moveSpeed -= damageToPlayerAge;
                    cooldownTimer = cooldownTime;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if(cooldownTimer > 0)
        {
            cooldownTimer -= Time.fixedDeltaTime;
        }
    }
}
