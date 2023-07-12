using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket_1BulletExplosion : MonoBehaviour
{
    public int numSprites = 9;
    public float FPS = 12f;

    void Start()
    {
        float tempoAnim = numSprites / FPS;
        Destroy(this.gameObject, tempoAnim);
    }
}
