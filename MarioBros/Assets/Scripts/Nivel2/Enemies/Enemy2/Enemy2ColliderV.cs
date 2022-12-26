using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2ColliderV : MonoBehaviour
{
    Rigidbody2D rb2d;
    GameObject EnemyObj;
    Animator marioAnim;
    public GameObject Mario;
    public float jumpPower;

    public static bool killedenemy;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = Mario.gameObject.GetComponent<Rigidbody2D>();
        EnemyObj = transform.parent.gameObject;
        marioAnim = Mario.GetComponent<Animator>();
        killedenemy = false;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            killedenemy = false;
            //AudioManager.PlaySound("killgoomba");
            //rb2d.AddForce(Vector2.up * jumpPower * 50);
            //Destroy(EnemyObj);
            marioAnim.SetBool("died", true);
        }
    }
}
