using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int hitPoints = 10;
    public bool alive = true;
    SpriteRenderer spriteRenderer;
    public Sprite skeleton;

    private void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void takeDamage(int dmg, GameObject dealer)
    {
        if(!alive)
        {
            return;
        }

        hitPoints -= dmg;

        if(dealer.GetComponent<HealthAbsorber>())
        {
            dealer.GetComponent<HealthAbsorber>().IncreaseYouthSpeed(dmg);
        }

        if(hitPoints <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        if(gameObject.GetComponent<AvoidPlayer>())
        {
            gameObject.GetComponent<AvoidPlayer>().Freeze();
        }
        if(spriteRenderer && skeleton)
        {
            spriteRenderer.sprite = skeleton;
        }
        else
        {
            Debug.Log("Failed to die lol");
        }
        
        alive = false;
    }
}
