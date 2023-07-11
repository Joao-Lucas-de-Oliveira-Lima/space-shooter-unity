using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject room;
    public int remainingEnemies;
    public int currentWave;
    public int totalWaves;
    // Start is called before the first frame update
    void Start()
    {
        currentWave = room.GetComponent<RoomController>().currentWave;
        totalWaves = room.GetComponent<RoomController>().waveCount;
    }

    // Update is called once per frame
    void Update()
    {
        //remainingEnemies = room.GetComponent<RoomController>().remainingEnemies;
        currentWave = room.GetComponent<RoomController>().currentWave;
        totalWaves = room.GetComponent<RoomController>().waveCount;

        if(currentWave == totalWaves)
        {
            try
            {
                GameObject door = GameObject.FindGameObjectWithTag("Door").gameObject;
                door.SetActive(false);
            }
            catch(System.Exception e)
            {

            }
            
            
           
        }

    }
}
