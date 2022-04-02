using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int hitPoints = 10;
    bool alive = true;

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
        
        alive = false;
    }
}
