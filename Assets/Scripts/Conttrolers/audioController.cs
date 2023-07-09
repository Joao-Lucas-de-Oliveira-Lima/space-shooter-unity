using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioClip redLaserBlast, explosion, singleBulletBlast;
    public static AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        redLaserBlast = Resources.Load("Audio/RedLaserBlast") as AudioClip;

        explosion = Resources.Load("Audio/Explosion") as AudioClip;

        singleBulletBlast = Resources.Load("Audio/SingleBulletBlast") as AudioClip;

        audioSource = GetComponent<AudioSource>();
    }
    public static void PlaySound(string audioClip)
    {
        switch (audioClip)
        {
            case "RedLaserBlast":
                audioSource.PlayOneShot(redLaserBlast);
                break;
            case "Explosion":
                audioSource.PlayOneShot(explosion);
                break;
            case "SingleBulletBlast":
                audioSource.PlayOneShot(singleBulletBlast);
                break;
        }
    }
}