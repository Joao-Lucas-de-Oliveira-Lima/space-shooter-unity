using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathToRoom03Script : MonoBehaviour
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
            GameObject.FindGameObjectWithTag("Door").GetComponent<DoorController>().ToggleTilemap(true);
            GameObject.FindGameObjectWithTag("Door").GetComponent<DoorController>().room = GameObject.FindGameObjectWithTag("ThirdRoom");
            GameObject.FindGameObjectWithTag("ThirdRoom").GetComponent<RoomController>().startWave = true;
            GameObject.FindGameObjectWithTag("CurrentRoom").GetComponent<CurrentRoomScript>().currentRoom = 3;
            Destroy(this.gameObject);
        }
        catch (System.Exception e)
        {
            Debug.Log(e.ToString());
        }

    }
}
