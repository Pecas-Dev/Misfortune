using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartFirstLevel : MonoBehaviour
{
    CharacterMove characterScriptReferenceFirstLevel;

    PolygonCollider2D restartColliderFirstLevel;

    [SerializeField] AudioSource deathAudioSourceFirstLevel;
    [SerializeField] AudioClip deathAudioClip;


    void Start()
    {
        deathAudioSourceFirstLevel = GetComponent<AudioSource>();
        restartColliderFirstLevel = GetComponent<PolygonCollider2D>();

        characterScriptReferenceFirstLevel = FindObjectOfType<CharacterMove>();

        deathAudioSourceFirstLevel.clip = deathAudioClip;
    }

    void Update()
    {
        if (restartColliderFirstLevel.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            /*if(!deathAudioSource.isPlaying)
            {
                deathAudioSource.PlayOneShot(deathAudioClip);
            }*/

            deathAudioSourceFirstLevel.Play();

            characterScriptReferenceFirstLevel.playerRb.velocity = new Vector2(0, 0);
            characterScriptReferenceFirstLevel.playerRb.constraints = RigidbodyConstraints2D.FreezeAll;

            characterScriptReferenceFirstLevel.playerAnimator.SetBool("isWalking", false);
            characterScriptReferenceFirstLevel.playerAnimator.SetFloat("walkingMultiplier", 0f);

            characterScriptReferenceFirstLevel.SetCanFlip(false);

            CameraShakeFirstLevel.Instance.CameraShakeGradualIncrease(3f);

            Invoke("RestartScene", 2.65f);

        }
    }

    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
