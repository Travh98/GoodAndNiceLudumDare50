using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgingSlowness : MonoBehaviour
{
    public float cooldownTime = 5f;  // Seconds before able to attack again
    private float cooldownTimer = 0f;
    public float speedLoss = 0.25f;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!gameObject.GetComponent<PlayerController>().alive)
        {
            return; // Do nothing, you dead
        }

        if (cooldownTimer <= 0)
        {
            gameObject.GetComponent<PlayerController>().moveSpeed -= speedLoss;
            cooldownTimer = cooldownTime;
            Debug.Log("Speed loss due to age, new speed:" +
                gameObject.GetComponent<PlayerController>().moveSpeed);
        }
        else
        {
            cooldownTimer -= Time.fixedDeltaTime;
        }
    }
}
