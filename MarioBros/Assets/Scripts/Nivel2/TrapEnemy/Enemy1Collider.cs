using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Collider : MonoBehaviour
{
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
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            //mario.transform.position = new Vector3(-11,0, mario.transform.position.z);
            marioAnim.SetBool("died", true);
        }
    }
}
