using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollision : MonoBehaviour
{
    Animator anim;
    Transform box;
    public Transform from;
    public Transform target;
    public float speed;
    float fixedspeed;
    Vector3 initialPosBoxx,initialPosTarget;
    // Start is called before the first frame update
    void Start()
    {
        anim = transform.parent.GetComponentInParent<Animator>();
        box = transform.parent.GetComponentInParent<Transform>();
        initialPosBoxx = box.position;
        initialPosTarget = target.position;
    }

    
    void Update()
    {
    }
    void FixedUpdate()
    {

        if (anim.GetBool("taked") == true)
        {
            fixedspeed = speed * Time.deltaTime;
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
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (anim.GetBool("taked") == false) { AudioManager.PlaySound("coinsound"); }
            anim.SetBool("taked", true);
        }
    }
    void OnDrawGizmosSelected()
    {
        if (from != null && target != null)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(from.position, target.position);
            Gizmos.DrawSphere(target.position, 0.15f);
        }
    }
}
