using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
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
}
