using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kino;

public class GlitchActivationFirstLevel : MonoBehaviour
{
    [SerializeField] DigitalGlitch glitchEffect;
    [SerializeField] float intensity;

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Vector2 distance = other.transform.position - transform.position;

            glitchEffect.intensity = intensity / distance.magnitude;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            glitchEffect.intensity = 0.0f;
        }
    }
}
