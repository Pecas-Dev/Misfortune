using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoNotDestroyOnLoadGlitchEffectLevels : MonoBehaviour
{
    static DoNotDestroyOnLoadGlitchEffectLevels instance;

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
