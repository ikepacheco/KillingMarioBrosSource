using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1RigidBody : MonoBehaviour
{
    public float speed;
    public float maxspeed;
    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        rb2d.AddForce(Vector2.right * speed);
        float limitspeed = Mathf.Clamp(rb2d.velocity.x, -maxspeed, maxspeed);
        rb2d.velocity = new Vector2(limitspeed, rb2d.velocity.y);
        if (rb2d.velocity.x > -0.01f && rb2d.velocity.x < 0.01f)
        {
            speed = -speed;
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
        }
        if (Enemy1ColliderV.killedenemy == true)
        {
            rb2d.velocity = new Vector2(0f, 0f);
            rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
}
