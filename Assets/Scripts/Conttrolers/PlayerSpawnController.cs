using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnController : MonoBehaviour
{
    public GameObject player, spawnPoint;
    public int CurrentSpawnPointOfThePlayer = 1;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if(player == null)
        {
            spawnPoint = VerifySpawnPoint();
            player = Instantiate(Resources.Load("Ships/Player") as GameObject, this.spawnPoint.transform.position, this.spawnPoint.transform.rotation);
            //player.GetComponent<PlayerStateController>().barsControllers = gameObject.AddComponent<BarsController>();
            player.GetComponent<PlayerStateController>().barsControllers = GameObject.Find("Bars").GetComponent<BarsController>() as BarsController;
            player.tag = "Player";
            //Destroy(GameObject.FindGameObjectWithTag("MainCamera").GetComponent<FollowThePlayer>());
            //GameObject.FindGameObjectWithTag("MainCamera").AddComponent<FollowThePlayer>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        this.CurrentSpawnPointOfThePlayer = GameObject.FindGameObjectWithTag("CurrentRoom").GetComponent<CurrentRoomScript>().currentRoom;
        if (player == null)
        {
            spawnPoint = VerifySpawnPoint();
            player = Instantiate(Resources.Load("Ships/Player") as GameObject, this.spawnPoint.transform.position, this.spawnPoint.transform.rotation);
            player.GetComponent<PlayerStateController>().barsControllers = GameObject.Find("Bars").GetComponent<BarsController>() as BarsController;
            player.tag = "Player";
            //Destroy(GameObject.FindGameObjectWithTag("MainCamera").GetComponent<FollowThePlayer>());
            //FindGameObjectWithTag("MainCamera").AddComponent<FollowThePlayer>();
        }
    }

    public GameObject VerifySpawnPoint()
    {
        if (this.CurrentSpawnPointOfThePlayer == 1)
        {
            return this.transform.Find("PlayerOneSpawnPoint").gameObject;
        }
        else if (this.CurrentSpawnPointOfThePlayer == 2)
        {
            return this.transform.Find("PlayerTwoSpawnPoint").gameObject;
        }
        else if (this.CurrentSpawnPointOfThePlayer == 3)
        {
            return this.transform.Find("PlayerThreeSpawnPoint").gameObject;
        }
        else if (this.CurrentSpawnPointOfThePlayer == 4)
        {
            return this.transform.Find("PlayerFourSpawnPoint").gameObject;
        }
        else if (this.CurrentSpawnPointOfThePlayer == 5)
        {
            return this.transform.Find("PlayerFiveSpawnPoint").gameObject;
        }
        return this.transform.Find("PlayerOneSpawnPoint").gameObject;
    }
}
