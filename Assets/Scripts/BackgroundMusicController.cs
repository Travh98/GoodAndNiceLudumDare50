using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicController : MonoBehaviour
{
    public GameObject playerController;
    public float playerStartingSpeed;
    public float pitch = 1.0f;
    public AudioSource backgroundMusic;

    void Update()
    {
        if(playerController)
        {
            float playerSpeed = playerController.GetComponent<PlayerController>().moveSpeed;
            backgroundMusic.pitch = playerSpeed / playerStartingSpeed;
            //Debug.Log("background musuic pitch: " + backgroundMusic.pitch);
        }
    }
}
