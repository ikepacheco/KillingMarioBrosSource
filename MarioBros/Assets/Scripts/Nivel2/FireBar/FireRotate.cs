using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRotate : MonoBehaviour
{
    public GameObject centerFire;
    public float speed;
    public Vector3 direction;
    public GameObject mario;
    Animator marioAnim;
    // Start is called before the first frame update
    void Start()
    {
        marioAnim = mario.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    void FixedUpdate()
    {
        transform.RotateAround(centerFire.transform.position, direction, speed);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            marioAnim.SetBool("died", true);
            //mario.transform.position = new Vector3(-11, 0,mario.transform.position.z);
        }
    }
}
