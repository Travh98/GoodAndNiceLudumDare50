using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int hitPoints = 10;

    public void takeDamage(int dmg)
    {
        hitPoints = hitPoints - dmg;
        if(hitPoints <= 0)
        {
            // Probably die
        }
    }
}
