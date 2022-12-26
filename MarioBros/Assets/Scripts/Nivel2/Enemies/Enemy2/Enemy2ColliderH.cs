using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2ColliderH : MonoBehaviour
{
    public GameObject Mario;
    Animator marioAnim;
    // Start is called before the first frame update
    void Start()
    {
        marioAnim = Mario.gameObject.GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if(Enemy2ColliderV.killedenemy == false) { 
                marioAnim.SetBool("died", true);
            }
        }
    }
}
