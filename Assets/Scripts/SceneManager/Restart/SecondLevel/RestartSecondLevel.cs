using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartSecondLevel : MonoBehaviour
{
    CharacterMove characterScriptReferenceSecondLevel;

    PolygonCollider2D restartColliderSecondLevel;

    [SerializeField] AudioSource deathAudioSourceSecondLevel;
    [SerializeField] AudioClip deathAudioClip;


    void Start()
    {
        deathAudioSourceSecondLevel = GetComponent<AudioSource>();
        restartColliderSecondLevel = GetComponent<PolygonCollider2D>();

        characterScriptReferenceSecondLevel = FindObjectOfType<CharacterMove>();

        deathAudioSourceSecondLevel.clip = deathAudioClip;
    }

    void Update()
    {
        if (restartColliderSecondLevel.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            /*if(!deathAudioSource.isPlaying)
            {
                deathAudioSource.PlayOneShot(deathAudioClip);
            }*/

            deathAudioSourceSecondLevel.Play();

            characterScriptReferenceSecondLevel.playerRb.velocity = new Vector2(0, 0);
            characterScriptReferenceSecondLevel.playerRb.constraints = RigidbodyConstraints2D.FreezeAll;

            characterScriptReferenceSecondLevel.playerAnimator.SetBool("isWalking", false);
            characterScriptReferenceSecondLevel.playerAnimator.SetFloat("walkingMultiplier", 0f);

            characterScriptReferenceSecondLevel.SetCanFlip(false);

            CameraShakeSecondLevel.Instance.CameraShakeGradualIncrease(3.65f);

            Invoke("RestartScene", 2.95f);

        }
    }

    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
