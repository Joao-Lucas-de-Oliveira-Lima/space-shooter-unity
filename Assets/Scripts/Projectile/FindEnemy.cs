using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindEnemy : MonoBehaviour
{
    public GameObject enemy;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("EnemyTest");
        
    }

    // Update is called once per frame
    void Update()
    {
          if(enemy != null)
        {
            this.transform.position = Vector2.MoveTowards(this.gameObject.transform.position, enemy.transform.position, speed * Time.deltaTime);
            //this.gameObject.transform.LookAt(enemy.transform, Vector3.up);
        }
    }
}


/*
         //Fazer com que todos os cubos andem ao jogador
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        this.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, player.transform.position, enemyVelocity);
        //Fazendo os cubos virarem para o jogador
        //Pegando o transform do do jogador e o eixo que o mesmo gira
        this.gameObject.transform.LookAt(player.transform, Vector3.up);
 */
