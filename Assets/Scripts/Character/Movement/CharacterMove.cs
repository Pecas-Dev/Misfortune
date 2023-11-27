using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public bool isPrincessGlitching = false;
    public float xInputValue;


    [SerializeField] public float playerSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;


    public Rigidbody2D playerRb;
    BoxCollider2D playerCollider;
    Animator playerAnimator;


    float yInputValue;


    bool isGrounded = false;
    bool canFlip = true;


    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();
        playerAnimator = GetComponent<Animator>();
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


        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f, LayerMask.GetMask("Ground"));

        bool isMovingHorizontal = Mathf.Abs(playerRb.velocity.x) > Mathf.Epsilon;


        if (hit.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if (isGrounded)
        {
            playerAnimator.SetBool("isWalking", isMovingHorizontal);
            playerAnimator.SetFloat("walkingMultiplier", 1f);
        }
        else
        {
            playerAnimator.SetBool("isWalking", isMovingHorizontal);
            playerAnimator.SetFloat("walkingMultiplier", 0f);
        }
    }

    void PlayerJump()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f, LayerMask.GetMask("Ground"));

        if (hit.collider != null)
        {
            isGrounded = true;
            playerAnimator.SetBool("isJump", false);
        }
        else
        {
            isGrounded = false;
            playerAnimator.SetBool("isJump", true);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerAnimator.SetBool("isJump", true);
            playerRb.velocity = new Vector2(0, jumpSpeed);
            isGrounded = false;
        }
    }

    void FlipCompleteCharacter()
    {
        bool isMovingHorizontal = Mathf.Abs(playerRb.velocity.x) > Mathf.Epsilon;

        if (isMovingHorizontal && !isPrincessGlitching && canFlip)
        {
            transform.localScale = new Vector2(Mathf.Sign(playerRb.velocity.x) * 0.15f, 0.15f);
        }
    }

    public void SetCanFlip(bool canFlipValue)
    {
        canFlip = canFlipValue;
    }

    void BlockMovement()
    {
        xInputValue = Input.GetAxis("Horizontal");

        if (playerCollider.IsTouchingLayers(LayerMask.GetMask("Princess")))
        {
            playerRb.velocity = new Vector2(0, 0);
            canFlip = false;
            playerRb.constraints = RigidbodyConstraints2D.FreezeAll;
            isPrincessGlitching = true;
        }
    }

}
