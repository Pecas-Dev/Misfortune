using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicMainMenu : MonoBehaviour
{
    [SerializeField] AudioClip song;
    [SerializeField] AudioSource audioSource;

    static MusicMainMenu instance_MainMenuSong;

    void Awake()
    {
        if (instance_MainMenuSong == null)
        {
            instance_MainMenuSong = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        audioSource.loop = true;
        audioSource.clip = song;
        audioSource.Play();
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Game_MainMenuScene" || scene.name == "Game_Options_MainMenu" || scene.name == "Game_SecretMenu_MainMenu")
        {
            if (!audioSource.isPlaying)
            {
                //audioSource.time = PlayerPrefs.GetFloat("SongPlaybackPosition", 0f);
                audioSource.Play();
            }
        }
        else if (scene.name == "FirstGameScene" || scene.name == "CreditsScene" || scene.name == "PreCreditsScene")
        {
            Destroy(gameObject);
        }
        else
        {
            //PlayerPrefs.SetFloat("SongPlaybackPosition", audioSource.time);
            //PlayerPrefs.Save();

            audioSource.Stop();
        }
    }
}
