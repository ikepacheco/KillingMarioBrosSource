using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSpikeCollider : MonoBehaviour
{
    public Transform spike;
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
            spike.position = Vector3.MoveTowards(spike.position, target.position, 10f * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            triggered = true;
        }
    }
}
