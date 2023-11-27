using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
    CharacterMove characterScript;

    PolygonCollider2D restartCollider;

    [SerializeField] AudioSource deathAudioSource;
    [SerializeField] AudioClip deathAudioClip;


    void Start()
    {
        deathAudioSource = GetComponent<AudioSource>();
        restartCollider = GetComponent<PolygonCollider2D>();

        characterScript = FindObjectOfType<CharacterMove>();

        deathAudioSource.clip = deathAudioClip;
    }

    void Update()
    {
        if (restartCollider.IsTouchingLayers(LayerMask.GetMask("Player")))
        {

            deathAudioSource.Play();

            characterScript.playerRb.velocity = new Vector2(0, 0);
            characterScript.playerRb.constraints = RigidbodyConstraints2D.FreezeAll;

            characterScript.SetCanFlip(false);

            Invoke("RestartScene", 0.65f);

        }
    }

    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
