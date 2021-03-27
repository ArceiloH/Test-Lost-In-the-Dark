using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] protected KeyCode runButton;
    
    private Rigidbody2D rb;
    [SerializeField] public float speed;
    [SerializeField] public float jumpForce;
    private float moveInput;

    private bool isGrounded;
    public Transform feetPos;
    [SerializeField] public float checkRadius;
    public LayerMask whatIsGround;

    private float jumpTimeCounter;
    [SerializeField] public float jumpTime;
    private bool isJumping;

    public Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }
    private void Update()
    {
        InputGetKeyMovement();
        animator.SetFloat("Speed", Mathf.Abs(moveInput));
        if (isGrounded==true)
        {
            animator.SetBool("Jumping", false);
        } else
        {
            animator.SetBool("Jumping", true);
        }
    }

    public void InputGetKeyMovement()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (Input.GetKeyDown(runButton))
        {
            speed = (float)(speed * 2);
            animator.SetBool("Running", true);
        }
        if (Input.GetKeyUp(runButton))
        {
            speed = (float)(speed / 2);
            animator.SetBool("Running", false);
        }

        if (moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }
        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }
}