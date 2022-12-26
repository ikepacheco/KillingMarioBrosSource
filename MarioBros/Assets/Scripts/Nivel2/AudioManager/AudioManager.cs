using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource debugCamSound;

    public static AudioSource camsound;
    public static AudioClip jumpsound, deadsound, coinsound, killgoomba;
    public static AudioClip Hurry, Default;
    public static AudioSource audioeffects;
    private void Start()
    {
        camsound = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        audioeffects = GetComponent<AudioSource>();
        //effects game
        jumpsound = Resources.Load<AudioClip>("Effects/jumpsound");
        deadsound = Resources.Load<AudioClip>("Effects/deadsound");
        coinsound = Resources.Load<AudioClip>("Effects/coinsound");
        killgoomba = Resources.Load<AudioClip>("Effects/killgoomba");

        //camera sounds
        Hurry = Resources.Load<AudioClip>("BackGround/Super Mario Bros. - HURRY (Overworld Theme)");
        Default = Resources.Load<AudioClip>("BackGround/Super Mario Bros (NES) Music - Overworld Theme");
    }
    public static void PlaySound(string s)
    {
        switch (s)
        {
            case "jumpsound":
                if (!audioeffects.isPlaying && Mario.jump) audioeffects.PlayOneShot(jumpsound, 0.4f);
                break;
            case "deadsound":
                if (!audioeffects.isPlaying) {
                    audioeffects.PlayOneShot(deadsound, 0.4f);
                }
                break;
            case "coinsound":
                audioeffects.PlayOneShot(coinsound, 0.4f);
                break;
            case "killgoomba":
                audioeffects.PlayOneShot(killgoomba, 2.0f);
                break;
        }
    }
    public static void PlaySoundCamera(string s)
    {
        switch (s)
        {
            case "Hurry":
                camsound.Stop();
                camsound.PlayOneShot(Hurry);
                //camsound.clip = Hurry;
                //camsound.Play();
                break;
            default:
                camsound.PlayOneShot(Hurry, 0.4f);
                break;
        }
    }
}
