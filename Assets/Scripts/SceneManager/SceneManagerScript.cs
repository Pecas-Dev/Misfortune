using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
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
}
