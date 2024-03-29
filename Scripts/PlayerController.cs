using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float horizontalInput;
    [SerializeField] private float moveSpeed = 8.0f;
    [SerializeField] private float jumpForce = 16.0f;
    [SerializeField] private bool isFacingRight = true;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform blockBouncingCheck;
    [SerializeField] private LayerMask blockLayer;
    [SerializeField] private AudioClip jumpSound;
    private AudioSource audioSource;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        bool isWalking = Mathf.Abs(horizontalInput) > 0.1f;
        animator.SetBool("isWalking", isWalking);

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            audioSource.PlayOneShot(jumpSound, 1.0f);
        }

        rb.velocity = (Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > 0f) ? new Vector2(rb.velocity.x, rb.velocity.y * 0.7f) : rb.velocity;

        Flip();
        IsBlockDetected();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private bool IsBlockDetected()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(blockBouncingCheck.position, 0.2f);

        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject.tag == "Block")
            {
                BlockController blockController = collider.GetComponent<BlockController>();
                if (blockController != null)
                {
                    blockController.BlockBounce();
                }
                return true;
            }
        }

        return false;
    }


    private void Flip()
    {
        if (isFacingRight && horizontalInput < 0 || !isFacingRight && horizontalInput > 0)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }
}