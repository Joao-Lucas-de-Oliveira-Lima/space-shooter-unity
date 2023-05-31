using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class movimentation : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float xDirection = Input.GetAxisRaw("Horizontal");
        float yDirection = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(xDirection, yDirection).normalized * speed;
    }
}
