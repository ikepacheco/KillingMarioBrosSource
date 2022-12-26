using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3RigidBody : MonoBehaviour
{
    public float speed;
    public float maxspeed;
    private Rigidbody2D rb2d;
    SpriteRenderer sprdr;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sprdr = GetComponent<SpriteRenderer>();
    }
    void FixedUpdate()
    {
        rb2d.AddForce(Vector2.right * speed);
        float limitspeed = Mathf.Clamp(rb2d.velocity.x,-maxspeed, maxspeed);
        rb2d.velocity = new Vector2(limitspeed, rb2d.velocity.y);
        if (rb2d.velocity.x > -0.01f && rb2d.velocity.x < 0.01f)
        {
            speed = -speed;
            sprdr.flipX = !sprdr.flipX;
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
        }
    }
}
