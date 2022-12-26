using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CameraMovement : MonoBehaviour
{
    [Header("Camera Limits")]
    //camara que sigue personaje mi manera
    public Transform marioPos;
    //camara que sigue personaje youtube
    public GameObject follow;
    public Vector2 minCamPosLand, maxCamPosLand;
    public Vector2 minCamPosPort, maxCamPosPort;
    public Vector2 minCamPosCuad, maxCamPosCuad;
    public float smoothTime;

    [Header ("Timer")]
    public Text timerTxt;

    float width, height;
    Vector2 velocity;
    string level;
    void Start()
    {
        if (DebugMode.debug_mode)
        {
            transform.position = new Vector3(0,3,-10);
        }
        level = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {

        width = Screen.width;
        height = Screen.height;
        //camara que sigue personaje mi manera
        //transform.position = Vector3.MoveTowards(transform.position, new Vector3(Mathf.Clamp(marioPos.position.x, 0f, 5f), transform.position.y, transform.position.z), 8.15f * Time.deltaTime);

        if (level == "Nivel2")
        {
            //camara que sigue personaje manera de youtube
            float posX = Mathf.SmoothDamp(transform.position.x, follow.transform.position.x, ref velocity.x, smoothTime);
            float posY = Mathf.SmoothDamp(transform.position.y, follow.transform.position.y, ref velocity.y, smoothTime);

            if (width > height)
            {
                transform.position = new Vector3(Mathf.Clamp(posX, minCamPosLand.x, maxCamPosLand.x), Mathf.Clamp(posY, minCamPosLand.y, maxCamPosLand.y), transform.position.z);
            }
            else if (width < height)
            {
                transform.position = new Vector3(Mathf.Clamp(posX, minCamPosPort.x, maxCamPosPort.x), Mathf.Clamp(posY, minCamPosPort.y, maxCamPosPort.y), transform.position.z);
            }
            else if (width == height)
            {
                transform.position = new Vector3(Mathf.Clamp(posX, minCamPosCuad.x, maxCamPosCuad.x), Mathf.Clamp(posY, minCamPosCuad.y, maxCamPosCuad.y), transform.position.z);
            }
            else
            {
                transform.position = new Vector3(Mathf.Clamp(posX, minCamPosCuad.x, maxCamPosCuad.x), Mathf.Clamp(posY, minCamPosCuad.y, maxCamPosCuad.y), transform.position.z);
            }
        }
        else if (level == "Nivel1")
        {
            //camara que sigue personaje manera de youtube
            float posX = Mathf.SmoothDamp(transform.position.x, follow.transform.position.x, ref velocity.x, smoothTime);
            float posY = Mathf.SmoothDamp(transform.position.y, follow.transform.position.y, ref velocity.y, smoothTime);
            if (width > height)
            {
                transform.position = new Vector3(Mathf.Clamp(posX, minCamPosLand.x, maxCamPosLand.x), Mathf.Clamp(posY, minCamPosLand.y, maxCamPosLand.y), transform.position.z);
            }
            else if (width < height)
            {
                transform.position = new Vector3(Mathf.Clamp(posX, minCamPosPort.x, maxCamPosPort.x), Mathf.Clamp(posY, minCamPosPort.y, maxCamPosPort.y), transform.position.z);
            }
            else if (width == height)
            {
                transform.position = new Vector3(Mathf.Clamp(posX, minCamPosCuad.x, maxCamPosCuad.x), Mathf.Clamp(posY, minCamPosCuad.y, maxCamPosCuad.y), transform.position.z);
            }
            else
            {
                transform.position = new Vector3(Mathf.Clamp(posX, minCamPosCuad.x, maxCamPosCuad.x), Mathf.Clamp(posY, minCamPosCuad.y, maxCamPosCuad.y), transform.position.z);
            }
        }

        }
    void FixedUpdate()
    {
        if (TimerScript.timer >= 99.9f && TimerScript.timer <= 100.0f)
        //if (int.Parse(timerTxt.text) == 101)
        {
            AudioManager.PlaySoundCamera("Hurry");
        }
    }
}