using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public AudioSource welcomeToBallZoneClip;
    private void Start()
    {
        welcomeToBallZoneClip.Play();       
    }

    public void quitOption()
    {
        Application.Quit();
    }

    public void playOption()
    {
        SceneManager.LoadScene("Level1");       
    }

    public void controlOption()
    {
        SceneManager.LoadScene("ControlsMenu");
    }

    public void levelSelectOption()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void howToPlayButton()
    {
        SceneManager.LoadScene("HowToPlay");
    }
}
