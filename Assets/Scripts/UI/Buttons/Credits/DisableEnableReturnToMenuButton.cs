using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DisableEnableReturnToMenuButton : MonoBehaviour
{
    Button returnToMenuButton;

    void Start()
    {
        returnToMenuButton = GetComponent<Button>();

        returnToMenuButton.interactable = false;

        StartCoroutine(DisableReturnToMenuButton());
        StartCoroutine(ReturnToMainMenu());
    }

    IEnumerator DisableReturnToMenuButton()
    {
        yield return new WaitForSeconds(30.0f);

        returnToMenuButton.interactable = true;
    }

    IEnumerator ReturnToMainMenu()
    {
        yield return new WaitForSeconds(65.0f);

        if (SceneManager.GetActiveScene().name == "CreditsScene")
        {
            SceneManager.LoadScene("Game_MainMenuScene");
        }
    }
}
