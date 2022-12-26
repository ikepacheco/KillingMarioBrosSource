using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1ColliderV : MonoBehaviour
{
    Rigidbody2D rb2d;
    GameObject EnemyObj;
    Animator anim;
    EdgeCollider2D edc2d;
    float timer;
    public GameObject Mario;
    public float jumpPower;
    public CapsuleCollider2D EnemyGCollider;

    public static bool killedenemy;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = Mario.gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponentInParent<Animator>();
        edc2d = gameObject.GetComponent<EdgeCollider2D>();
        EnemyObj = transform.parent.gameObject;
        killedenemy = false;
    }
    void FixedUpdate()
    {
        if (killedenemy == true)
        {
            timer += Time.deltaTime;
        }
        //Debug.Log(timer);
        if (timer > 1f)
        {
            Destroy(EnemyObj);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            killedenemy = true;
            anim.SetBool("Destroyed", killedenemy);
            AudioManager.PlaySound("killgoomba");
            rb2d.AddForce(Vector2.up * jumpPower * 50);
            edc2d.enabled = false;
            EnemyGCollider.enabled = false;
        }
    }
}
