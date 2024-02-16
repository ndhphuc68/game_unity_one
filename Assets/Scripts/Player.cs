using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer rbSprite;
    private BoxCollider2D boxCollider;
    private Animator animator;

    [SerializeField] private LayerMask layerMask;

    private float dirX = 0f;
    private float speedRun = 7f;
    private float jumpForce = 14f;

    private enum PlayerState { idle, running, jumping, falling }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rbSprite = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovePlayer();
    }

    private void HandleMovePlayer()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(speedRun * dirX, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        HandleAnimation();
    }

    private void HandleAnimation()
    {
        PlayerState state;

        if (dirX > 0f)
        {
            state = PlayerState.running;
            rbSprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = PlayerState.running;
            rbSprite.flipX = true;
        }
        else
        {
            state = PlayerState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = PlayerState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = PlayerState.falling;
        }

        animator.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, .1f, layerMask);
    }
}
