using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoNotDestroyOnLoadPlayerLevels : MonoBehaviour
{
    static DoNotDestroyOnLoadPlayerLevels instance;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "DecoyMenuScene")
        {
            Destroy(gameObject);
        }
    }
}
