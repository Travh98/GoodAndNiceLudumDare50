using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthAbsorber : MonoBehaviour
{
    public float healthToSpeedMultiplier = 0.5f;
    public void IncreaseYouthSpeed(int healthUnits)
    {
        gameObject.GetComponent<PlayerController>().moveSpeed +=
            healthUnits * healthToSpeedMultiplier;
        Debug.Log("Player speed increased");
    }
}
