using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    Text txt;
    float vel;
    public Animator marioAnim;
    public static float timer;
    // Start is called before the first frame update
    void Start()
    {
        txt = this.GetComponent<Text>();
        timer = 400.0f;
        vel = 1;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime * vel;
        txt.text = timer.ToString("0");
        if (timer <= 100) vel = 2;
        if (timer <= 0){
            marioAnim.SetBool("died", true);
        }
        if (marioAnim.GetBool("died") == true)
        {
            vel = 0;
        }
    }
}
