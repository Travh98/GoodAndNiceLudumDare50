using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject MainMenuUI;
    public GameObject HowToPanel;
    public GameObject Button;

    [SerializeField]
    private string startLevelName;

    private void Awake()
    {
        HowToPanel.SetActive(false);
        

        //if (PlayerPrefs.GetFloat("gameVolume") >= 1)
        //{
        //    PlayerPrefs.SetFloat("gameVolume", 0.25f);
        //    Debug.Log("We set volume to" + PlayerPrefs.GetFloat("gameVolume"));
        //    AudioListener.volume = PlayerPrefs.GetFloat("gameVolume");
        //}
        //else
        //{
        //    //Debug.Log("We set volume to" + PlayerPrefs.GetFloat("gameVolume"));
        //}
    }

    public void Play()
    {
        HowToPanel.SetActive(true);
    }
    public void Next()
    {
        SceneManager.LoadScene("MainLevel");
    }
}