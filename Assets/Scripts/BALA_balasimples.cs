using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BALA_balasimples : MonoBehaviour
{

    public float incremento = 0.05f;
    //public string TagToIgnore = "inimigo";


    // Start is called before the first frame update
    void Start()
    {
   
    }



    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Translate(Vector2.down * incremento * Time.deltaTime);

    }

    private void OnCollisionEnter2D(Collision2D other) //OBS: TEM QUE SER 2D. SE N�O COLOCAR O 2D, N�O FUNCIONA
    {
        if (other.gameObject.tag.Equals("parede"))
        {
            Debug.Log("acertou!!");
            //Destroy(other.gameObject);
            Destroy(this.gameObject);
        }else if(other.gameObject.tag.Equals("Player"))
        {
            Destroy(this.gameObject);
        }

        //if (other.gameObject.tag == TagToIgnore)
        //{
            //Physics2D.IgnoreCollision(this.gameObject.GetComponent<Collider2D>(), other.gameObject.GetComponent<Collider2D>());
        //}
    }
}
