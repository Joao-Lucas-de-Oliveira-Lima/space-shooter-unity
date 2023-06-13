using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BALAestacionario : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) //OBS: TEM QUE SER 2D. SE NAO COLOCAR O 2D, NAO FUNCIONA
    {
        if (other.gameObject.tag.Equals("parede"))
        {
            Debug.Log("acertou!!");
            //Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        else if (other.gameObject.tag.Equals("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
