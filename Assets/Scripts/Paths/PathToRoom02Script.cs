using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PathToRoom02Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Caminho bloqueado");
        GameObject c = GameObject.Find("FirstRoom");
        c.SetActive(true);
        if(c == null)
        {

        }
        else
        {
            Debug.Log(c);
        }
        try
        {
            GetComponent<DoorController>().room = GameObject.FindGameObjectWithTag("SecondRoom");
            GameObject.FindGameObjectWithTag("Door").SetActive(true);
            GameObject.FindGameObjectWithTag("SecondRoom").SetActive(true);
            Destroy(this.gameObject);
        }catch(System.Exception e)
        {
            Debug.Log(e.ToString());
        }
               
    }
}
