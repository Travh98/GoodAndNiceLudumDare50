using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgingSlowness : MonoBehaviour
{
    public float cooldownTime = 5f;  // Seconds before able to attack again
    private float cooldownTimer = 0f;
    public float speedLoss = 0.25f;
    public float timeBeforeRestart = 6.0f;

    SpriteRenderer spriteRenderer;
    public Sprite skeleton;
    public GameObject husband;

    private void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void OnDeath()
    {
        if (spriteRenderer && skeleton)
        {
            spriteRenderer.sprite = skeleton;
        }
        else
        {
            Debug.Log("Failed to die lol");
        }
        if (gameObject.GetComponent<AudioSource>())
        {
            gameObject.GetComponent<AudioSource>().Play();
        }
        if (husband.GetComponentInChildren<RandomDialog>())
        {
            RandomDialog husbandDialog = husband.GetComponentInChildren<RandomDialog>();
            husbandDialog.dialogList.Clear();
            husbandDialog.dialogList.Add("Don't leave me...");
            husbandDialog.dialogList.Add("I'll miss you");
            husbandDialog.dialogList.Add(":(");
            husbandDialog.ShowRandomDialog();
        }
        else
        {
            Debug.Log("Failed to get husbands dialog");
        }
    }

    void FixedUpdate()
    {
        if(!gameObject.GetComponent<PlayerController>().alive)
        {
            OnDeath();
            Destroy(this);
            return; // Do nothing, you dead
        }

        if (cooldownTimer <= 0)
        {
            gameObject.GetComponent<PlayerController>().moveSpeed -= speedLoss;
            cooldownTimer = cooldownTime;
        }
        else
        {
            cooldownTimer -= Time.fixedDeltaTime;
        }
    }
}
