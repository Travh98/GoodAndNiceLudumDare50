using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustVolume : MonoBehaviour
{
    public float volume = 1.0f;

    void Update()
    {
        AudioListener.volume = volume;
    }
}
