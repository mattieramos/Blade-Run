using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void LoadTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadScores()
    {
        SceneManager.LoadScene("HighScores");

    }

    public void MenuScreen()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
