using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Dissolve : MonoBehaviour
{
    Material material;
    bool fadeIn = false;
    public float fade = 1f;
    public float fadeTimeScale = 2f;
    public float minScale = 35.0f;
    public float maxScale = 60.0f;
    public float scale = 35.0f;

    // Start is called before the first frame update
    void Start()
    {
        if(GetComponent<SpriteRenderer>())
        {
            material = GetComponent<SpriteRenderer>().material;
        }
        if (GetComponent<TilemapRenderer>())
        {
            material = GetComponent<TilemapRenderer>().material;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // pulse between fully faded and fully visible
        if(fade <= 0.25f)
        {
            fadeIn = true;
        }
        if (fade >= 1)
        {
            fadeIn = false;
        }
        if(fadeIn)
        {
            fade += Time.deltaTime / fadeTimeScale;
        }
        else
        {
            fade -= Time.deltaTime / fadeTimeScale;
        }
        material.SetFloat("_Fade", fade);

//        if(scale >= minScale)
//        {
//            scale -= Time.deltaTime;
//        }
//        else
//        {
//            scale = maxScale;
//        }
//        material.SetFloat("_Scale", scale);
    }
}
