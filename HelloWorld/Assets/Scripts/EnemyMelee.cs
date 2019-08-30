using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour
{
    public float speed;
    public Transform[] Points = new Transform[2];
    Rigidbody2D rb;
    SpriteRenderer sr;
    bool OnRight;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void enemyRun()
    {
        sr.flipX = OnRight;
        if (gameObject.transform.position.x <= Points[0].position.x)
        {
            OnRight = false;
        }
        else if ((gameObject.transform.position.x >= Points[1].position.x))
        {
            OnRight = true;
        }
        if (!OnRight)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }

    }

    void Update()
    {
        enemyRun();
    }
}
