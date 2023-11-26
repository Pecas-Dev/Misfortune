using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnableVersionFour : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textVersion4;

    void Start()
    {
        textVersion4.enabled = false;

        StartCoroutine(EnableDisableLoopVersion2());
    }

    IEnumerator EnableDisableLoopVersion2()
    {
        yield return new WaitForSeconds(3.5f);

        while (true)
        {
            textVersion4.enabled = true;

            yield return new WaitForSeconds(1f);

            textVersion4.enabled = false;

            yield return new WaitForSeconds(1.8f);
        }
    }
}
