using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrincessGlitchAnimTest : MonoBehaviour
{
    BoxCollider2D princessCollider;
    CapsuleCollider2D princessColliderSecondLevel;
    Animator princessGlitchAnimatorTest;

    void Start()
    {
        princessCollider = GetComponent<BoxCollider2D>();
        princessGlitchAnimatorTest = GetComponent<Animator>();
        princessColliderSecondLevel = GetComponent<CapsuleCollider2D>();
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

        if ((princessColliderSecondLevel.IsTouchingLayers(LayerMask.GetMask("Player"))))
        {
            princessGlitchAnimatorTest.SetBool("isMajorGlitch", true);
        }
        else
        {
            princessGlitchAnimatorTest.SetBool("isMajorGlitch", false);
        }
    }

}
