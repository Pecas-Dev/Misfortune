using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisableEnableReturnToMenuButtonVisual : MonoBehaviour
{
    TextMeshProUGUI textReturnToMainMenuButton;

    void Start()
    {
        textReturnToMainMenuButton = GetComponent<TextMeshProUGUI>();

        textReturnToMainMenuButton.enabled = false;
        textReturnToMainMenuButton.alpha = 0.0f;

        StartCoroutine(DisableReturnToMenuButton());
    }

    IEnumerator DisableReturnToMenuButton()
    {
        yield return new WaitForSeconds(30.0f);

        textReturnToMainMenuButton.enabled = true;
        StartCoroutine(FadeInText());
    }

    IEnumerator FadeInText()
    {
        float currentTime = 0.0f;
        float duration = 5.0f;

        while (currentTime < duration)
        {
            float alpha = Mathf.Lerp(0.0f, 1.0f, currentTime / duration);
            textReturnToMainMenuButton.alpha = alpha;

            currentTime += Time.deltaTime;
            yield return null;
        }

        textReturnToMainMenuButton.alpha = 1.0f;
    }
}
