using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenuScript : MonoBehaviour
{
    public void NextLevelOption()
    {
        SceneManager.LoadScene("TestLevel");
    }
}
