using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSkyCollider : MonoBehaviour
{
    public GameObject Mario;
    Animator marioAnim;
    public GameObject groundSky;
    GameObject gs;
    // Start is called before the first frame update
    void Start()
    {
        marioAnim = Mario.gameObject.GetComponent<Animator>();
        gs = groundSky.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("DownFloor"))
        {
            Debug.Log("Limit Map Taked");
            //Destroy(gs);
        }
        
        if (col.gameObject.tag == "Player")
        {
            marioAnim.SetBool("died", true);
        }

    }
    private void OnBecameInvisible()
    {
        
         
        
    }
}
