using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedLaserExplosion : MonoBehaviour
{
    public int numSprites = 4;
    public float FPS = 12f;

    void Start()
    {
        float tempoAnim = numSprites / FPS;
        Destroy(this.gameObject, tempoAnim);
    }
}
