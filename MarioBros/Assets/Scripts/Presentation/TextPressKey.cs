using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPressKey : MonoBehaviour
{
    Text txt;
    Color t_color;
    int alpha;
    int fadeTime = 3;
    bool simbol;
    public GameObject Mario;
    Animator animMario;
    // Start is called before the first frame update
    void Start()
    {
        txt = gameObject.GetComponent<Text>();
        alpha = 255;
        simbol = false;
        animMario = Mario.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!animMario.GetBool("KeyPressed"))
        {
            t_color = new Color32(255, 255, 255, (byte)alpha);
            if (simbol == false)
            {
                alpha -= fadeTime;
                txt.color = t_color;
                if (alpha == 0) simbol = true;
            }
            else if (simbol == true)
            {
                alpha += fadeTime;
                txt.color = t_color;
                if (alpha == 255) simbol = false;
            }
        }
        

        if (Input.anyKey)
        {
            animMario.SetBool("KeyPressed", true);
            Destroy(txt);
        }
    }
}
