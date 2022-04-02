using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RandomDialog : MonoBehaviour
{
    public float textUpTime = 5f; // Const
    float textUpTimer = 0f;

    public float minTextSpawnTime = 5f;  // Const
    public float maxTextSpawnTime = 30f;  // Const
    float randomTextTimer = 0f;

    TextMeshProUGUI textMeshPro;
    public List<string> dialogList;

    void Start()
    {
        textMeshPro = gameObject.GetComponent<TextMeshProUGUI>();
        if(textMeshPro == null)
        {
            Debug.Log("Failed to get TextMeshPro");
        }
        randomTextTimer = textUpTime;  // initializer
        textMeshPro.text = "beef";
    }

    void FixedUpdate()
    {
        if(textUpTimer > 0)
        {
            textUpTimer -= Time.fixedDeltaTime;
        }
        else
        {
            HideDialog();
        }

        if(randomTextTimer > 0)
        {
            randomTextTimer -= Time.fixedDeltaTime;
        }
        else
        {
            ShowRandomDialog();
            setTextSpawnTimer();
        }

    }

    void ShowRandomDialog()
    {
        if(textMeshPro)
        {
            int randomIndex = Random.Range(0, dialogList.Count - 1);
            textMeshPro.text = dialogList[randomIndex];
            textMeshPro.enabled = true;
            textUpTimer = textUpTime;
        }
    }
    void HideDialog()
    {
        if(textMeshPro)
        {
            textMeshPro.enabled = false;
        }
    }

    void setTextSpawnTimer()
    {
        randomTextTimer = textUpTime + Random.Range(minTextSpawnTime, maxTextSpawnTime);
    }
}
