using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDied : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("StartScene");
    }
}

