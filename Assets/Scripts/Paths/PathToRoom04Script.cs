using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathToRoom04Script : MonoBehaviour
{
    //public GameObject door;
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


        try
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                GameObject.FindGameObjectWithTag("Door").GetComponent<DoorController>().ToggleTilemap(true);
                GameObject.FindGameObjectWithTag("Door").GetComponent<DoorController>().room = GameObject.FindGameObjectWithTag("FourthRoom");
                GameObject.FindGameObjectWithTag("FourthRoom").GetComponent<RoomController>().startWave = true;
                GameObject.FindGameObjectWithTag("CurrentRoom").GetComponent<CurrentRoomScript>().currentRoom = 4;
                Destroy(this.gameObject);
            }
                
        }
        catch (System.Exception e)
        {
            Debug.Log(e.ToString());
        }

    }
}
