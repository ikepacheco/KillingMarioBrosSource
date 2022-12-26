using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyGround : MonoBehaviour
{
    bool triggered = false;
    Rigidbody2D rbd2d;
    public Transform mario;
    // Start is called before the first frame update
    void Start()
    {
        rbd2d = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(transform.GetComponentInChildren<EdgeCollider2D>().enabled);
        if (mario.localPosition.y < transform.localPosition.y + 0.5f)
        {
            transform.GetComponentInChildren<EdgeCollider2D>().enabled = false;
        }
        else
        {
            transform.GetComponentInChildren<EdgeCollider2D>().enabled = true;
        }
        if (triggered && Mario.grounded == true) 
        {
            rbd2d.constraints = RigidbodyConstraints2D.None;
            rbd2d.constraints = RigidbodyConstraints2D.FreezePositionX;
            rbd2d.constraints = RigidbodyConstraints2D.FreezeRotation;
            rbd2d.gravityScale = 1;
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            triggered = true;

        }
    }
}
