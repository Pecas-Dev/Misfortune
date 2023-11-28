using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnableDisableButtonVersionThree : MonoBehaviour
{
    [SerializeField] Button textVersion3Button;

    void Start()
    {
        textVersion3Button.interactable = false;

        StartCoroutine(EnableDisableLoopVersion2());
    }

    IEnumerator EnableDisableLoopVersion2()
    {
        yield return new WaitForSeconds(2.75f);

        while (true)
        {
            textVersion3Button.interactable = true;

            yield return new WaitForSeconds(1f);

            textVersion3Button.interactable = false;

            yield return new WaitForSeconds(2.5f);
        }
    }
}


