﻿using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts.Conttrolers
{ 
    public class PlayerSpaceshipController : MonoBehaviour
    {
        public IWeapon primaryWeapon, secondaryWeapon;
        public float nextPrimaryWeaponFire = 0.0f, nextScondaryWeaponFire = 0.0f;
        public float primaryWeaponFireRate = 0.5f, secondaryWeaponFireRate = 0.5f;

        public Vector3 directionToBeMoved;
        public Vector3 offset;
        public float velocity = 5f;

        public float speed = 5f;

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
                primaryWeapon.Shoot();
                
            }
            if(Input.GetKey(KeyCode.Mouse1) && Time.time > nextScondaryWeaponFire)
            {
                nextScondaryWeaponFire = Time.time + secondaryWeaponFireRate;
                secondaryWeapon.Shoot();
            }

            //Movimentation
            directionToBeMoved = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            offset = this.transform.position + directionToBeMoved;
            Vector3 desiredPosition = directionToBeMoved + offset;
            Vector3 smoothedPosition = Vector3.Lerp(this.transform.position, desiredPosition, velocity * Time.deltaTime);
            this.transform.position = smoothedPosition;

            //Rotation
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 directionToBeRotated = mousePosition - transform.position;
            float angle = Vector2.SignedAngle(Vector2.up, directionToBeRotated);
            //Smooth rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, angle), speed * Time.fixedDeltaTime);
        }

    }
}