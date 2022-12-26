using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MarioControllerMenu : MonoBehaviour
{
    DebugMode.SO so = new DebugMode.SO();

    public GameObject AndroidStartPosition;
    public GameObject CameraPosition;
    private void Start()
    {
        so.GetSO();
        if (so.android)
        {
            transform.position = new Vector3(AndroidStartPosition.transform.position.x, AndroidStartPosition.transform.position.y, AndroidStartPosition.transform.position.z);
        }
    }
    private void Update()
    {
        if (so.android)
        {
            CameraPosition.transform.position = new Vector3(Mathf.Clamp(transform.position.x, 0, 7.5f), CameraPosition.transform.position.y, CameraPosition.transform.position.z);
        }
    }
    
    private void OnBecameInvisible()
    {
        SceneManager.LoadScene("Menu");
    }
    
}
