using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlyingGravity : MonoBehaviour
{
    Rigidbody2D rb2d;
    EnemyFlyingTrigger eft;
    float leftForce = 325f;
    GameObject enemieFlyObject;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        eft = gameObject.AddComponent<EnemyFlyingTrigger>();
        enemieFlyObject = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (eft.wallCollided == true)
        {
            rb2d.constraints = RigidbodyConstraints2D.None;
        }
    }
    private void FixedUpdate()
    {
        if (eft.wallCollided == true) { 
            rb2d.AddForce(Vector2.left * leftForce);
            rb2d.velocity = new Vector2(rb2d.velocity.x * 0.3333f, rb2d.velocity.y);
            //Debug.Log(eft.wallCollided);
        }
    }
    private void OnBecameInvisible()
    {
        if (eft.wallCollided == true)
        {
            Destroy(enemieFlyObject);

        }
    }
}
