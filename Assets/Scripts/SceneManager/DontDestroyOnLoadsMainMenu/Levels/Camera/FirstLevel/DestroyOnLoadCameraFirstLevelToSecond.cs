using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyOnLoadCameraFirstLevelToSecond : MonoBehaviour
{
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "SecondGameScene")
        {
            Destroy(gameObject);
        }
    }
}
