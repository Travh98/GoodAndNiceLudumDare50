using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBeam : MonoBehaviour
{
    public GameObject receiverObject;
    public GameObject giverObject;
    public ParticleSystem pSystem;
    public bool doGiveParticles;
    float giveTimer = 0f;
    public float giveCooldownTime = 1f;

    // Take particles from giver and send to receiver
    public void setGiver(GameObject giver)
    {
        giverObject = giver.gameObject;
    }
    public void setGiving(bool giving)
    {
        doGiveParticles = giving;
    }

    public void fireParticles()
    {
        pSystem.Play();
        gameObject.GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(doGiveParticles && giveTimer <= 0)
        {
            fireParticles();
            giveTimer = giveCooldownTime;
        }
        if(giveTimer > 0)
        {
            giveTimer -= Time.deltaTime;
        }

        if(giverObject)
        {
            pSystem.transform.position = giverObject.transform.position;
            Vector3 direction = receiverObject.transform.position -
                giverObject.transform.position;
            int left;
            if(direction.x > 0)
            {
                left = -1;  // its right
            }
            else
            {
                left = 1;
            }
            Quaternion rotation = 
                Quaternion.Euler(0, 0, 
                left * Vector3.Angle(giverObject.transform.up, direction));
            pSystem.transform.rotation = rotation;
        }
       
    }
}
