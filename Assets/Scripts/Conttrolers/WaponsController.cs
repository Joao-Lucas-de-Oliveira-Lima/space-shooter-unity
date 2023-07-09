using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.UIElements;


public interface IWeapon
{
    public void Shoot();
}


public class RedLaser : MonoBehaviour, IWeapon 
{
    public float projectileForce = 80000f;
    public GameObject shootingPoint;

    public void Start()
    {
        shootingPoint = transform.Find("ShootingPoint").gameObject;
    }
    public void Shoot()
    {
        GameObject projectile = Instantiate(Resources.Load("Weapons/RedLaser", typeof(GameObject)), shootingPoint.transform.position, shootingPoint.transform.rotation) as GameObject;
        Rigidbody2D rigidbody = projectile.GetComponent<Rigidbody2D>();
        rigidbody.AddForce(shootingPoint.transform.up * projectileForce * Time.fixedDeltaTime);
        AudioController.PlaySound("RedLaserBlast");
    }
}

public class Rocket_1 : MonoBehaviour,IWeapon
{
    public GameObject shootingPoint;
    public float projectileForce = 50000f;
    public void Start()
    {
        shootingPoint = GameObject.Find("ShootingPoint");
       
    }
    public void Shoot()
    {
        GameObject projectile = Instantiate(Resources.Load("Weapons/Rocket_1") as GameObject, shootingPoint.transform.position, shootingPoint.transform.rotation);
        Rigidbody2D rigidbody = projectile.GetComponent<Rigidbody2D>();
        rigidbody.AddForce(shootingPoint.transform.up * projectileForce * Time.fixedDeltaTime);
    }
}

public class BalaSimples_1 : MonoBehaviour, IWeapon
{
    public GameObject naveJogador;
    public float intervaloDisparo = 0.5f; // Intervalo de tempo entre os disparos
    public float intensidade = 10f; // Intensidade do disparo
    private bool detectado = false;
    private float tempoDecorrido = 0f; // Tempo decorrido desde o último disparo

    public GameObject shootingPoint;
    public float projectileForce = 65000f;

    void Start()
    {

        this.naveJogador = GameObject.FindGameObjectWithTag("Player");
        shootingPoint = transform.Find("ShootingPoint").gameObject;

    }

    /*
    void Update()
    {
        // tempoDecorrido += Time.deltaTime; // Atualiza o tempo decorrido a cada quadro

        //if (tempoDecorrido >= intervaloDisparo)
        //{
        //    Atirar();
        //    tempoDecorrido = 0f; // Reinicia o tempo decorrido
        //}

        //pelo código acima também dá pra fazer disparar em um intervalo fixo de tempo, só que não consegui fazer funcionar pelo
        //trigger do collider. Acho que é pq ele precisa estar no Update(), por conta da contagem de tempo (eu acho).
    }
    */

    public void Shoot()
    {
      
        GameObject projectile = Instantiate(Resources.Load("Weapons/BalaSimples") as GameObject, shootingPoint.transform.position, shootingPoint.transform.rotation);
        Rigidbody2D rigidbody = projectile.GetComponent<Rigidbody2D>();
        rigidbody.AddForce(this.transform.up * projectileForce * Time.deltaTime);
        AudioController.PlaySound("SingleBulletBlast");

    }

    /*

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Aqui");
        if (other.tag.ToString() == naveJogador.tag.ToString())
        {
            detectado = true;
            Debug.Log("detectado");
            InvokeRepeating(nameof(Shoot), 0f, intervaloDisparo);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == naveJogador)
        {
            detectado = false; //quando o jogador sai da área do trigger (é um collider 2D), aí o detectado fica falso
            Debug.Log("fugiu!");
            CancelInvoke(nameof(Shoot));
        }
    }

    */

}