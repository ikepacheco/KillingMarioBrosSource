using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapFloorCollider : MonoBehaviour
{
    public Transform[] floor;
    bool trapOn = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(trapOn);
        if (trapOn == true)
        {
            /*for (int i = 0; i < floor.Length; i++)
            {
                floor[i].position = Vector3.MoveTowards(floor[i].position,new Vector3(floor[i].position.x, floor[i].position.y - 15f, floor[i].position.z), 10f * Time.deltaTime);
            }*/
            foreach (Transform i in floor)
            {
                i.position = Vector3.MoveTowards(i.position, new Vector3(i.position.x, i.position.y - 15f, i.position.z), 10f * Time.deltaTime);
            }

        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            trapOn = true;
        }
    }

}
