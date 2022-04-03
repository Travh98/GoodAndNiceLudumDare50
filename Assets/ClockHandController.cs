using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockHandController : MonoBehaviour
{
    public GameObject playerObject;

    void Update()
    {
        float playerSpeed = playerObject.GetComponent<PlayerController>().moveSpeed;
        float clockAngle = 0 + playerSpeed * 30.0f;
        Quaternion targetRotation = Quaternion.Euler(0, 0, clockAngle);
        gameObject.transform.rotation = targetRotation;
    }
}
