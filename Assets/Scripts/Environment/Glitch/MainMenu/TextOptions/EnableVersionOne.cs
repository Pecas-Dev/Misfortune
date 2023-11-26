using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnableVersionOne : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textVersion1;

    void Start()
    {
        textVersion1.enabled = true;

        StartCoroutine(EnableDisableLoopVersion1());
    }

    IEnumerator EnableDisableLoopVersion1()
    {
        while (true)
        {
            textVersion1.enabled = true;

            yield return new WaitForSeconds(1f);

            textVersion1.enabled = false;

            yield return new WaitForSeconds(2f);
        }
    }
}
