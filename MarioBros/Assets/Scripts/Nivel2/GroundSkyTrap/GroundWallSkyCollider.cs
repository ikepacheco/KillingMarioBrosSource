using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundWallSkyCollider : MonoBehaviour
{
    public GameObject GroundSky;
    public Transform target;
    bool triggered = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(triggered == true)
        {
            GroundSky.transform.position = Vector3.MoveTowards(transform.position,target.position, 15 * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, target.position, 15 * Time.deltaTime);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            triggered = true;
        }
    }
}
