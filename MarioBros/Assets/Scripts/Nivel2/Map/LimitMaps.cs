using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitMaps : MonoBehaviour
{
    public Animator marioAnim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            marioAnim.SetBool("died", true);
        } 
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "ColliderGroundSky")
        {
            Debug.Log("Limit Map Taked");
        }
    }
}
