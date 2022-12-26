using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InviCoinCollision : MonoBehaviour
{
    EdgeCollider2D bc2dchild;
    Animator anim;
    public Transform mario;
    public Animator marioAnim;

    // Start is called before the first frame update
    void Start()
    {
        bc2dchild = transform.GetChild(0).GetComponentInChildren<EdgeCollider2D>();
        anim = transform.GetChild(0).GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {

        if (anim.GetBool("taked") == false)
        {
            if ((mario.position.y + mario.localScale.y) < transform.position.y)
            {
                bc2dchild.enabled = true;
            }
            else
            {
                bc2dchild.enabled = false;
            }
        }
    }
}
