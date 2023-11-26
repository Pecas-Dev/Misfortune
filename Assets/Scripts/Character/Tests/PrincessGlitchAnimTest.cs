using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrincessGlitchAnimTest : MonoBehaviour
{
    BoxCollider2D princessCollider;
    Animator princessGlitchAnimatorTest;

    void Start()
    {
        princessCollider = GetComponent<BoxCollider2D>();
        princessGlitchAnimatorTest = GetComponent<Animator>();
    }

    void Update()
    {
        if(princessCollider.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            princessGlitchAnimatorTest.SetBool("isGlitch", true);
        }
        else
        {
            princessGlitchAnimatorTest.SetBool("isGlitch", false);
        }

        if (Input.GetKey(KeyCode.J))
        {
            princessGlitchAnimatorTest.SetBool("isMajorGlitch", true);
        }
        else
        {
            princessGlitchAnimatorTest.SetBool("isMajorGlitch", false);
        }
    }
}
