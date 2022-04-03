using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthAbsorber : MonoBehaviour
{
    public float healthToSpeedMultiplier = 0.5f;
    ParticleSystem particles;

    private void Start()
    {
        particles = gameObject.GetComponentInChildren<ParticleSystem>();
    }
    public void IncreaseYouthSpeed(int healthUnits)
    {
        gameObject.GetComponent<PlayerController>().moveSpeed +=
            healthUnits * healthToSpeedMultiplier;
        Debug.Log("Player speed increased");
        if(particles)
        {
            particles.Play();
        }
        else
        {
            Debug.Log("Failed to find particle system");
        }
    }
}
