using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyOnLoadCameraSecondLevelToDecoy : MonoBehaviour
{
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "DecoyMenuScene")
        {
            Destroy(gameObject);
        }
    }
}
