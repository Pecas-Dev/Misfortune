using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnableVersionThree : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textVersion3;

    void Start()
    {
        textVersion3.enabled = false;

        StartCoroutine(EnableDisableLoopVersion2());
    }

    IEnumerator EnableDisableLoopVersion2()
    {
        yield return new WaitForSeconds(2.75f);

        while (true)
        {
            textVersion3.enabled = true;

            yield return new WaitForSeconds(1f);

            textVersion3.enabled = false;

            yield return new WaitForSeconds(2.5f);
        }
    }
}
