using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class KillSphere : MonoBehaviour
{
    public GameObject parent;
    public LayerMask targetLayer;
    public DeathBeam beam;
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
                Health targetHealth = collision.gameObject.GetComponent<Health>();
                if (targetHealth.alive)
                {
                    beam.setGiver(collision.gameObject);
                    beam.setGiving(true);
                }
                else
                {
                    beam.setGiving(false);
                }
                targetHealth.takeDamage(damage, parent);
                cooldownTimer = cooldownTime;
            }
            if(collision.gameObject.GetComponent<PlayerController>())
            {
                PlayerController pController = 
                    collision.gameObject.GetComponent<PlayerController>();
                if (pController.alive)
                {
                    beam.setGiver(collision.gameObject);
                    beam.setGiving(true);

                    pController.moveSpeed -= damageToPlayerAge;
                    cooldownTimer = cooldownTime;
                }
                else
                {
                    beam.setGiving(false);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        beam.setGiving(false);
    }

    private void FixedUpdate()
    {
        if(cooldownTimer > 0)
        {
            cooldownTimer -= Time.fixedDeltaTime;
        }
    }
}
