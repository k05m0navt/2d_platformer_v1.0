using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    public float speed;
    public bool isKey;
    public static bool isKeyValue;
    public static int scoreAmount;
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
    int scene_index;


    private void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        scoreAmount = 0;
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            scene_index = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(scene_index);
        }
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
