using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    string gitHubURL = "https://github.com/Pecas-Dev/Misfortune";

    void Update()
    {
        LevelNameCheck();
    }

    void LevelNameCheck()
    {
        if (SceneManager.GetActiveScene().name == "Screamer")
        {
            StartCoroutine(PreCreditsTransition());
        }

        if (SceneManager.GetActiveScene().name == "PreCreditsScene")
        {
            StartCoroutine(CreditsTransition());
        }
    }

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

    public void FromOptionsToSecretMenuScene()
    {
        if (SceneManager.GetActiveScene().name == "Game_Options_MainMenu")
        {
            SceneManager.LoadScene("Game_SecretMenu_MainMenu");
        }
    }

    public void FromSecretMenuToMainMenuScene()
    {
        if (SceneManager.GetActiveScene().name == "Game_SecretMenu_MainMenu")
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

    // DEBUG 

    public void ToCreditsScene()
    {
        if (SceneManager.GetActiveScene().name == "Game_MainMenuScene")
        {
            SceneManager.LoadScene("CreditsScene");
        }
    }

    IEnumerator PreCreditsTransition()
    {
        yield return new WaitForSeconds(16f);

        SceneManager.LoadScene("PreCreditsScene");
    }

    IEnumerator CreditsTransition()
    {
        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene("CreditsScene");
    }
}
