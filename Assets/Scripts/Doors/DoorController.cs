using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DoorController : MonoBehaviour
{
    public GameObject room;
    //public int remainingEnemies;
    public int currentWave;
    public int totalWaves;

    public TilemapRenderer tilemapRenderer;
    public TilemapCollider2D tilemapCollider;

    // Start is called before the first frame update
    void Start()
    {
        room = GameObject.FindGameObjectWithTag("FirstRoom");
        currentWave = room.GetComponent<RoomController>().currentWave;
        totalWaves = room.GetComponent<RoomController>().waveCount;
        tilemapRenderer = this.GetComponent<TilemapRenderer>();
        tilemapCollider = this.GetComponent<TilemapCollider2D>();
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
                ToggleTilemap(false);
                Debug.Log(tilemapCollider);
                Debug.Log(tilemapRenderer);
            }catch(System.Exception e)
            {

            }
        }

    }

    public void ToggleTilemap(bool active)
    {
        // Ativa ou desativa o componente Tilemap Renderer
        tilemapRenderer.enabled = active;

        // Ativa ou desativa o componente Tilemap Collider 2D
        tilemapCollider.enabled = active;
    }

}
