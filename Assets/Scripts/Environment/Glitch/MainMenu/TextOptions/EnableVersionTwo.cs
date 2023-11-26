using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnableVersionTwo : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textVersion2;

    void Start()
    {
        textVersion2.enabled = false;

        StartCoroutine(EnableDisableLoopVersion2());
    }

    IEnumerator EnableDisableLoopVersion2()
    {
        yield return new WaitForSeconds(1.5f);

        while (true)
        {
            textVersion2.enabled = true;

            yield return new WaitForSeconds(1f);

            textVersion2.enabled = false;

            yield return new WaitForSeconds(2f);
        }
    }
}
