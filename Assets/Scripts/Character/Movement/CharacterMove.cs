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

    public bool isPrincessGlitching = false;



    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        PlayerMovement();
        PlayerJump();

        FlipCompleteCharacter();

        BlockMovement();
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
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f, LayerMask.GetMask("Ground"));

        if (hit.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRb.velocity = new Vector2(0, jumpSpeed);
            isGrounded = false;
        }
    }

    void FlipCompleteCharacter()
    {
        bool isMovingHorizontal = Mathf.Abs(playerRb.velocity.x) > Mathf.Epsilon;

        if (isMovingHorizontal && !isPrincessGlitching)
        {
            transform.localScale = new Vector2(Mathf.Sign(playerRb.velocity.x) * 0.15f, 0.15f);
        }
    }

    void BlockMovement()
    {
        if (playerCollider.IsTouchingLayers(LayerMask.GetMask("Princess")))
        {
            playerRb.velocity = new Vector2(0, 0);
            isPrincessGlitching = true;
        }
    }
}
