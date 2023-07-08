using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoForceCollision : MonoBehaviour
{
    //Para fins de teste
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Desativa temporariamente o RigidBody2D
        this.GetComponent<Rigidbody2D>().isKinematic = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Reativa o RigidBody2D
        this.GetComponent<Rigidbody2D>().isKinematic = false;
    }
}