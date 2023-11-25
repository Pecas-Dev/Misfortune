using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    [SerializeField] float playerSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;


    Rigidbody2D playerRb;
    BoxCollider2D playerCollider;
    //Animator playerAnimator;

    float xInputValue;
    float yInputValue;


    bool isGrounded = false;


    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        PlayerMovement();
        PlayerJump();
    }

    void PlayerMovement()
    {
        xInputValue = Input.GetAxis("Horizontal");
        yInputValue = Input.GetAxis("Vertical");

        Vector2 playerVelocity = new Vector2(xInputValue * playerSpeed, playerRb.velocity.y);

        playerRb.velocity = playerVelocity;
    }

    void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (playerCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
            {
                isGrounded = true;
            }
            else
            {
                isGrounded = false;
            }

            if (isGrounded == true)
            {
                playerRb.velocity = new Vector2(0, jumpSpeed);
                isGrounded = false;
            }
        }
    }
}
