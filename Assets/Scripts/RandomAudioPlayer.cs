using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAudioPlayer : MonoBehaviour
{
    public const float typicalFreq = 10f;
    public const float typicalVariance = 5f;
    float soundTimer = 0;

    void Update()
    {
        if(soundTimer <= 0 && gameObject.GetComponent<AudioSource>())
        {
            gameObject.GetComponent<AudioSource>().Play();
            soundTimer = Random.Range(typicalFreq - typicalVariance,
                typicalFreq + typicalVariance);
        }
        else
        {
            soundTimer -= Time.deltaTime;
        }
    }
}
