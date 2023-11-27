using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    string gitHubURL = "https://github.com/Pecas-Dev/Misfortune";

    public void ToStartScene()
    {
        if (SceneManager.GetActiveScene().name == "Game_MainMenuScene")
        {
            SceneManager.LoadScene("FirstGameScene");
        }
    }

    public void ToOptionscene()
    {
        if (SceneManager.GetActiveScene().name == "Game_MainMenuScene")
        {
            SceneManager.LoadScene("Game_Options_MainMenu");
        }
    }

    public void ToMainMenuScene()
    {
        if (SceneManager.GetActiveScene().name == "Game_Options_MainMenu")
        {
            SceneManager.LoadScene("Game_MainMenuScene");
        }
    }

    public void ToScreamerScene()
    {
        if (SceneManager.GetActiveScene().name == "DecoyMenuScene")
        {
            SceneManager.LoadScene("Screamer");
        }
    }

    public void FromCreditsToMainMenuScene()
    {
        if (SceneManager.GetActiveScene().name == "CreditsScene")
        {
            SceneManager.LoadScene("Game_MainMenuScene");
        }
    }

    public void QuitGame()
    {
        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            Application.OpenURL(gitHubURL);
            Application.Quit();
        }
        else if (Application.platform == RuntimePlatform.WindowsPlayer)
        {
            Application.Quit();
        }
        else
        {
            Application.Quit();
        }
    }
}
