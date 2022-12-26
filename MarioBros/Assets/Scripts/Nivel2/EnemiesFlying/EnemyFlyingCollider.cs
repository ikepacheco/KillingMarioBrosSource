using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlyingCollider : MonoBehaviour
{
    public GameObject Mario;
    Animator marioAnim;
    // Start is called before the first frame update
    void Start()
    {
        marioAnim = Mario.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            marioAnim.SetBool("died", true);
        }

    }
}
