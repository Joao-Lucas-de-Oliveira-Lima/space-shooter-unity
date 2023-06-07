using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Conttrolers
{
    public enum WeaponType
    {
        primary,
        missile
    }
    public class spaceshipController : MonoBehaviour
    {
        public WeaponType weaponType;
        public Weapon currentWeapon;
        public float fireRate = 0.1F;
        private float nextFire = 0.0F;
        void Start()
        {
            currentWeapon = gameObject.AddComponent<RedLaser>();
        }
        void Update()
        {
            if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0)) && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                currentWeapon.shoot();
            }
        }
    }
}