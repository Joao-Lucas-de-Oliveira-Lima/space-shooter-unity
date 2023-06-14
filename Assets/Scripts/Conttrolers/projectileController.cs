using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.UIElements;

public class playerBullet : MonoBehaviour
{
}

public interface Weapon
{
    public void shoot();
}
public class RedLaser : MonoBehaviour, Weapon
{
    public float projectileForce = 70000f;
    public GameObject shootingPoint;

    public void Start()
    {
        shootingPoint = GameObject.Find("ShootingPoint");
    }
    public void shoot()
    {
        GameObject projectile = Instantiate(Resources.Load("Weapons/RedLaser", typeof(GameObject)), shootingPoint.transform.position, shootingPoint.transform.rotation) as GameObject;
        Rigidbody2D rigidbody = projectile.GetComponent<Rigidbody2D>();
        rigidbody.AddForce(shootingPoint.transform.up * projectileForce * Time.fixedDeltaTime);
    }
}

public class Rocket_1 : MonoBehaviour, Weapon
{
    public GameObject shootingPoint;
    public float projectileForce = 50000f;
    public void Start()
    {
        shootingPoint = GameObject.Find("ShootingPoint");
    }
    public void shoot()
    {
        GameObject projectile = Instantiate(Resources.Load("Weapons/Rocket_1") as GameObject, shootingPoint.transform.position, shootingPoint.transform.rotation);
        Rigidbody2D rigidbody = projectile.GetComponent<Rigidbody2D>();
        rigidbody.AddForce(shootingPoint.transform.up * projectileForce * Time.fixedDeltaTime);
    }
}