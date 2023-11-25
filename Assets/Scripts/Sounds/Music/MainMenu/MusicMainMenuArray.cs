using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicMainMenuArray : MonoBehaviour
{
    [SerializeField] AudioClip[] songs;
    [SerializeField] AudioSource audioSource;


    int currentSongIndex = 0;

    static MusicMainMenuArray instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            audioSource.loop = false;
        }
        else
        {
            Destroy(gameObject);
        }
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

        if (scene.name == "Game_MainMenuScene" || scene.name == "Game_Options_MainMenu")
        {
            if (!audioSource.isPlaying || audioSource.time > audioSource.clip.length - 1f)
            {
                PlaySong();
            }
        }
        else
        {
            audioSource.Stop();
        }
    }

    void PlaySong()
    {
        float songStartTime = PlayerPrefs.GetFloat("SongStartTime", 0f);

        audioSource.clip = songs[currentSongIndex];

        if (audioSource.time == 0f || audioSource.time > audioSource.clip.length - 1f)
        {
            songStartTime = Time.time;
            audioSource.Play();
        }
        else
        {
            audioSource.Play();
            audioSource.time = Time.time - songStartTime;
        }

        StartCoroutine(WaitForSongEnd());
    }

    IEnumerator WaitForSongEnd()
    {
        yield return new WaitForSeconds(0.1f);

        if (SceneManager.GetActiveScene().name == "Game_MainMenuScene" || SceneManager.GetActiveScene().name == "Game_Options_MainMenu")
        {
            yield return new WaitForSeconds(audioSource.clip.length - audioSource.time);

            PlayerPrefs.SetFloat("SongStartTime", Time.time);
            PlayerPrefs.Save();

            currentSongIndex = (currentSongIndex + 1) % songs.Length;

            PlaySong();
        }
    }

}
