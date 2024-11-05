using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectMenu : MonoBehaviour
{
    public void Level1Option()
    {
        SceneManager.LoadScene("Level1");
    }

    public void LevelTestOption()
    {
        SceneManager.LoadScene("TestLevel");
    }

    public void GoBackOption()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
