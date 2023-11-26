using Kino;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlitchActivationMainMenu : MonoBehaviour
{
    //TEST -> Not intended behaviour, but could be implemented in another way for a future project.

    /*[SerializeField] DigitalGlitch glitchEffect;
    [SerializeField] AnalogGlitch analogGlitchEffect;

    [SerializeField] float minIntensity = 0f;
    [SerializeField] float maxIntensity = 0.5f;

    [SerializeField] float glitchDuration = 2f;
    [SerializeField] float pauseDuration = 10f;
    [SerializeField] float initialDelay = 8f;

    void Update()
    {
        StartCoroutine(StartGlitchWithDelay());
    }

    IEnumerator StartGlitchWithDelay()
    {
        yield return new WaitForSeconds(initialDelay);
        StartCoroutine(RepeatGlitchPattern());
    }

    IEnumerator RepeatGlitchPattern()
    {
        while (true)
        {
            StartCoroutine(VaryIntensity());
            yield return new WaitForSeconds(glitchDuration);

            StartCoroutine(PauseIntensity());
        }
    }

    IEnumerator PauseIntensity()
    {
        while (true)
        {
            glitchEffect.intensity = 0f;
            analogGlitchEffect.colorDrift = 0f;
            yield return new WaitForSeconds(pauseDuration);
        }
    }

    IEnumerator VaryIntensity()
    {
        while (true)
        {
            float randomIntensity = Random.Range(minIntensity, maxIntensity);

            glitchEffect.intensity = randomIntensity;
            analogGlitchEffect.colorDrift = randomIntensity;

            yield return new WaitForSeconds(0);
        }
    }*/
    [Header("Glitch Effect Scripts")]
    [SerializeField] DigitalGlitch glitchEffect;
    [SerializeField] AnalogGlitch analogGlitchEffect;

    [Header("Intensity")]
    [SerializeField] float minIntensity = 0f;
    [SerializeField] float maxIntensity = 0.5f;

    [SerializeField] float minIntensityHorizontalShake = 0f;
    [SerializeField] float maxIntensityHorizontalShake = 0.25f;

    [Header("Duration")]
    [SerializeField] float glitchDuration = 5f;
    [SerializeField] float pauseDuration = 10f;
    [SerializeField] float initialDelay = 5f;

    [Header("Audio")]
    [SerializeField] AudioClip glitchSoundClip;
    [SerializeField] AudioSource glitchAudioSource;

    bool isGlitching = false;

    void Start()
    {
        glitchAudioSource.clip = glitchSoundClip;

        StartCoroutine(StartGlitchWithDelay());
    }

    IEnumerator StartGlitchWithDelay()
    {
        yield return new WaitForSeconds(initialDelay);
        StartCoroutine(RepeatGlitchPattern());
    }

    IEnumerator RepeatGlitchPattern()
    {
        while (true)
        {
            StartCoroutine(VaryIntensity());
            yield return new WaitForSeconds(glitchDuration);


            isGlitching = false;

            glitchEffect.intensity = 0f;
            analogGlitchEffect.colorDrift = 0f;
            analogGlitchEffect.horizontalShake = 0f;

            glitchAudioSource.Stop();

            yield return new WaitForSeconds(pauseDuration);
        }
    }

    IEnumerator VaryIntensity()
    {
        isGlitching = true;

        glitchAudioSource.pitch = Random.Range(1f, 2.5f);
        glitchAudioSource.Play();

        while (isGlitching)
        {
            float randomIntensity = Random.Range(minIntensity, maxIntensity);
            float randomIntensityHorizontalShake = Random.Range(minIntensityHorizontalShake, maxIntensityHorizontalShake);

            glitchEffect.intensity = randomIntensity;
            analogGlitchEffect.colorDrift = randomIntensity;
            analogGlitchEffect.horizontalShake = randomIntensityHorizontalShake;

            yield return new WaitForSeconds(0);
        }
    }
}
