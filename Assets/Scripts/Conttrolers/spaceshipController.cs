using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Conttrolers
{ 
    public class spaceshipController : MonoBehaviour
    {
        public Weapon primaryWeapon, secondaryWeapon;
        public float nextPrimaryWeaponFire = 0.0f, nextScondaryWeaponFire = 0.0f;
        public float primaryWeaponFireRate = 0.5f, secondaryWeaponFireRate = 0.5f;
        void Start()
        {
            primaryWeapon = gameObject.AddComponent<RedLaser>();
            secondaryWeapon = gameObject.AddComponent<Rocket_1>();
        }
        void Update()
        {
            //Shoot
            if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0)) && Time.time > nextPrimaryWeaponFire)
            {
                nextPrimaryWeaponFire = Time.time + primaryWeaponFireRate;
                primaryWeapon.shoot();
                audioController.playSound("RedLaserBlast");
            }
            if(Input.GetKey(KeyCode.Mouse1) && Time.time > nextScondaryWeaponFire)
            {
                nextScondaryWeaponFire = Time.time + secondaryWeaponFireRate;
                secondaryWeapon.shoot();
            }
            //Movimentation
        }
    }
}