using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapCollider : MonoBehaviour
{
    public Transform enemy;
    public Transform target;
    public GameObject Mario;
    Animator marioAnim;
    Vector3 initialposenemy;
    bool triggered = false;
    bool died;
    // Start is called before the first frame update
    void Start()
    {
        initialposenemy = enemy.position;
        marioAnim = Mario.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        died = marioAnim.GetBool("died");
    }
    void FixedUpdate()
    {
        if (triggered == true)
        {
            enemy.position = Vector3.MoveTowards(enemy.position, target.position, 9f * Time.deltaTime);
        }
        if (enemy.position == target.position)
        {
            enemy.position = initialposenemy;
            triggered = false;
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (died == false)
            {
                triggered = true;
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        if (enemy != null && target != null)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(enemy.position, target.position);
            Gizmos.DrawSphere(target.position, 0.15f);
        }
    }
}
