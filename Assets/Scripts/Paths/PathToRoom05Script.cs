using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PathToRoom05Script : MonoBehaviour
{
    //public GameObject door;
    public int currentWave = -1;
    public int totalWaves = -2;
    public float delay = 1f;
    public GameObject[] enemies;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            currentWave = GameObject.FindGameObjectWithTag("FifthRoom").GetComponent<RoomController>().currentWave;
            totalWaves = GameObject.FindGameObjectWithTag("FifthRoom").GetComponent<RoomController>().waveCount;
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
            if (currentWave >= totalWaves)
            {
                StartCoroutine((ChangeSceneWithDelay(delay)));
            }
        }catch(System.Exception e)
        {

        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        try
        {
            if(collision.gameObject.CompareTag("Player"))
            {
                GameObject.FindGameObjectWithTag("Door").GetComponent<DoorController>().ToggleTilemap(true);
                GameObject.FindGameObjectWithTag("Door").GetComponent<DoorController>().room = GameObject.FindGameObjectWithTag("FifthRoom");
                GameObject.FindGameObjectWithTag("FifthRoom").GetComponent<RoomController>().startWave = true;
                GameObject.FindGameObjectWithTag("CurrentRoom").GetComponent<CurrentRoomScript>().currentRoom = 5;
                currentWave = GameObject.FindGameObjectWithTag("FifthRoom").GetComponent<RoomController>().currentWave;
                totalWaves = GameObject.FindGameObjectWithTag("FifthRoom").GetComponent<RoomController>().waveCount;
                this.gameObject.GetComponent<EdgeCollider2D>().enabled = false;
                //Destroy(this.gameObject);
            }
        }
        catch (System.Exception e)
        {
            Debug.Log(e.ToString());
        }

    }

    IEnumerator ChangeSceneWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Congratulations"); // Substitua "NomeDaCena" pelo nome da cena que você deseja carregar
    }

}
