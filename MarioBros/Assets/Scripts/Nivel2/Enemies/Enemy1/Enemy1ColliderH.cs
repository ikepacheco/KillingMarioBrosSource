using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1ColliderH : MonoBehaviour
{
    public GameObject Mario;
    Animator marioAnim;
    CapsuleCollider2D capc2d;
    // Start is called before the first frame update
    void Start()
    {
        marioAnim = Mario.gameObject.GetComponent<Animator>();
        capc2d = gameObject.GetComponent<CapsuleCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if(Enemy1ColliderV.killedenemy == false) { 
                marioAnim.SetBool("died", true);
            }
            if(Enemy1ColliderV.killedenemy == true)
            {
                capc2d.enabled = false;
            }
        }
    }
}
