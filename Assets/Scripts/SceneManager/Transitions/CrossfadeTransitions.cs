using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrossfadeTransitions : MonoBehaviour
{
    [SerializeField] Animator crossfadeAnimator;


    CharacterMove playerScript;

    void Start()
    {
        playerScript = FindObjectOfType<CharacterMove>();
    }

    void Update()
    {
        LevelNameCheck();
    }

    void LevelNameCheck()
    {
        if (SceneManager.GetActiveScene().name == "Game_MainMenuScene")
        {
            StartCoroutine(FirstLevelTransition());
        }

        if (SceneManager.GetActiveScene().name == "FirstGameScene")
        {
            StartCoroutine(SecondLevelTransition());
        }

        if (SceneManager.GetActiveScene().name == "SecondGameScene")
        {
            StartCoroutine(DecoyLevelTransition());
        }
    }

    IEnumerator FirstLevelTransition()
    {
        crossfadeAnimator.SetTrigger("Start");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene("FirstGameScene");
    }

    IEnumerator SecondLevelTransition()
    {
        if (playerScript.isPrincessGlitching == true)
        {
            yield return new WaitForSeconds(2.5f);

            crossfadeAnimator.SetTrigger("Start");

            yield return new WaitForSeconds(3.5f);

            SceneManager.LoadScene("SecondGameScene");
        }
    }

    IEnumerator DecoyLevelTransition()
    {
        if (playerScript.isPrincessGlitching == true)
        {
            yield return new WaitForSeconds(2.5f);

            crossfadeAnimator.SetTrigger("Start");

            yield return new WaitForSeconds(4.25f);

            SceneManager.LoadScene("DecoyMenuScene");
        }
    }
}
