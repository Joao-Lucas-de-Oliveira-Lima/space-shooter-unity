using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploInimigos : MonoBehaviour
{
    public int numSprites = 26;
    public float FPS = 12f;

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
