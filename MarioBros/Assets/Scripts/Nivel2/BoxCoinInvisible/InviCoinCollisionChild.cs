using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InviCoinCollisionChild : MonoBehaviour
{
    Animator anim;
    BoxCollider2D bc2dparent;
    EdgeCollider2D bc2dchild;
    Transform box;
    public Transform from;
    public Transform target;
    public float speed;
    public Animator marioAnim;
    float fixedspeed;
    Vector3 initialPosBoxx;
    void Start()
    {
        bc2dparent = transform.parent.GetComponentInParent<BoxCollider2D>();
        bc2dchild = transform.GetChild(0).GetComponentInChildren<EdgeCollider2D>();
        anim = GetComponent<Animator>();
        box = GetComponent<Transform>();
        initialPosBoxx = box.position;
    }
    void FixedUpdate()
    {
        if (anim.GetBool("taked") == true)
        {
            fixedspeed = speed * 30 * Time.deltaTime;
            if (box.position != target.position)
            {
                box.transform.position = Vector3.MoveTowards(box.transform.position,
                    target.transform.position,
                    fixedspeed);
            }
            else
            {
                target.position = initialPosBoxx;
            }
        }

     }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (marioAnim.GetBool("died") == false)
            {
                anim.SetBool("taked", true);
                bc2dparent.enabled = true;
                bc2dchild.enabled = true;
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        if (from != null && target != null)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(from.position, target.position);
            Gizmos.DrawSphere(target.position, 0.15f);
            Gizmos.DrawWireCube(transform.position, transform.localScale);
        }
    }
}
