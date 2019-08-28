using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float speed;
    public static bool isKey;
    public static bool isKeyValue;
    public float jumpForce;
    private float moveInput;
    public bool isGrounded;
    public float checkRadius;
    private int extraJumps;
    public int extraJumpsValue;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;

    private void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void checkJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            anim.SetBool("isJump", true);
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true)
        {
            anim.SetBool("isJump", true);
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
    }

    void checkRun()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if (moveInput > 0)
        {
            anim.SetBool("isRun", true);
            sprite.flipX = false;
        }
        else if (moveInput < 0)
        {
            sprite.flipX = true;
            anim.SetBool("isRun", true);
        }
        else
        {
            anim.SetBool("isRun", false);
        }
    }

    void checkDie()
    {

    }

    void CheckGround()
    {
        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
            anim.SetBool("isJump", false);
        }
    }

    void checkKey()
    {
        isKey = isKeyValue;
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        checkRun();
        CheckGround();
        checkJump();
        checkKey();

    }
}
