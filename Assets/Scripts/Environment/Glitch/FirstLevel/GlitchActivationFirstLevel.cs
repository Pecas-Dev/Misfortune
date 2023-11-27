using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kino;
using Cinemachine;
using Unity.VisualScripting;

public class GlitchActivationFirstLevel : MonoBehaviour
{
    CharacterMove characterScript;

    [SerializeField] CameraShakeFirstLevel cameraShakeScriptFirstLevel;

    [SerializeField] DigitalGlitch glitchEffect;
    [SerializeReference] AudioSource glitchAudioSource;
    [SerializeField] AudioClip glitchClip;
    [SerializeField] public float intensity;
    [SerializeField] float cameraShakeIntensity;


    void Start()
    {
        glitchAudioSource.clip = glitchClip;
        glitchAudioSource.volume = 0.25f;

        characterScript = FindObjectOfType<CharacterMove>();
    }

    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Vector2 distance = other.transform.position - transform.position;

            glitchEffect.intensity = intensity / distance.magnitude;

            float calculatedVolume = Mathf.Clamp(0.1f / distance.magnitude * 5.0f, 0f, 0.9f);

            glitchAudioSource.volume = calculatedVolume;


            if (!glitchAudioSource.isPlaying)
            {
                glitchAudioSource.Play(); 
            }

            characterScript.playerSpeed = distance.magnitude / 5f;

            CameraShakeFirstLevel.Instance.CameraShakeGradualIncrease(cameraShakeIntensity / distance.magnitude);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            glitchEffect.intensity = 0.0f;
            characterScript.playerSpeed = 5.0f;

            glitchAudioSource.volume = 0.25f;

            CameraShakeFirstLevel.Instance.CameraShakeGradualIncrease(0.0f);

           glitchAudioSource.Stop();
        }
    }
}
