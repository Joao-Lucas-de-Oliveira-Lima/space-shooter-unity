using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioClip redLaserBlast;
    public static AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        redLaserBlast = Resources.Load("Audio/RedLaserBlast") as AudioClip;

        audioSource = GetComponent<AudioSource>();
    }
    public static void playSound(string audioClip)
    {
        switch (audioClip)
        {
            case "RedLaserBlast":
                audioSource.PlayOneShot(redLaserBlast);
                break;
        }
    }
}
