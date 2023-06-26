using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXPLO_inimigos : MonoBehaviour
{
    public int numSprites = 10;
    public float FPS = 30f;

    // Start is called before the first frame update
    void Start()
    {
        float tempoAnim = numSprites / FPS;
        Destroy(this.gameObject, tempoAnim);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
