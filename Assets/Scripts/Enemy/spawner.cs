using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    //public GameObject enemyShip;
    public Transform playerPosition;
    public Camera camera;
    public float cameraWidth, cameraHeight, playerSpriteSize = 0.6f;
    // Start is called before the first frame update
    void Start()
    {
        //this.enemyShip = Resources.Load("Ships/Enemy") as GameObject;
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] allEnemys = GameObject.FindGameObjectsWithTag("EnemyTest") as GameObject[];
        if(allEnemys.Length == 0)
        {
            //Capturing camera coords
            cameraWidth = camera.aspect + 5f;
            cameraHeight = camera.orthographicSize * 2f;
            float leftSide = ((cameraWidth) - camera.transform.position.x) *- 1f;
            float rightSide = (cameraWidth) + camera.transform.position.x;
            float bottom = ((cameraHeight / 2f) - camera.transform.position.y) * -1f;
            float up = (cameraHeight / 2f) + camera.transform.position.y;
            Debug.Log(leftSide+" "+rightSide);

            //EnemyPosition
            float enemyPositionX, enemyPositionY;
            enemyPositionX = enemyPositionY = 0;
            while (!(enemyPositionX >= playerPosition.position.x - (playerSpriteSize  / 2f) && enemyPositionX <= playerPosition.position.x + (playerSpriteSize / 2f)))
            {
                float test = Random.Range(leftSide, rightSide);
                if(test != enemyPositionX)
                {
                    enemyPositionX = test;
                    break;
                }
            }
            while (!(enemyPositionY >= playerPosition.position.y - (playerSpriteSize / 2f) && enemyPositionY <= playerPosition.position.y + (playerSpriteSize / 2f)))
            {
                float test = Random.Range(bottom, up);
                if(test != enemyPositionY)
                {
                    enemyPositionY = Random.Range(bottom, up);
                    break;
                }
            }
            //CreatingEnemy
            GameObject enemy = Instantiate(Resources.Load("Ships/Enemy") as GameObject);
            enemy.transform.localPosition = new Vector2(enemyPositionX, enemyPositionY);
        }
    }
}
