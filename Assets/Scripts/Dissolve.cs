using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolve : MonoBehaviour
{
    Material material;
    bool fadeIn = false;
    public float fade = 1f;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        // pulse between fully faded and fully visible
        if(fade <= 0)
        {
            fadeIn = true;
        }
        if (fade >= 1)
        {
            fadeIn = false;
        }
        if(fadeIn)
        {
            fade += Time.deltaTime;
        }
        else
        {
            fade -= Time.deltaTime;
        }
        material.SetFloat("_Fade", fade);
    }
}
