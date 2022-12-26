using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEvent : MonoBehaviour
{
    // Start is called before the first frame update
    public void SelectLvl1()
    {
        SceneManager.LoadScene("Nivel1");
    }
    public void SelectLvl2()
    {
        SceneManager.LoadScene("Nivel2");
    }
    public void Exit()
    {
        SceneManager.LoadScene("Presentation");
    }
}
