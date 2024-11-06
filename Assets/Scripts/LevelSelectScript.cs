using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectScript : MonoBehaviour
{
    public void Level1Button()
    {
        SceneManager.LoadScene("Level1");
    }

    public void LevelTestButton()
    {
        SceneManager.LoadScene("TestLevel");
    }

    public void GoBackButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
