using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class movimentation : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    public float speed;
    public void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float xDirection = Input.GetAxisRaw("Horizontal");
        float yDirection = Input.GetAxisRaw("Vertical");
        rigidbody.velocity = new Vector2(xDirection, yDirection).normalized * speed * Time.deltaTime;
        //transform.position = Vector2.SmoothDamp(transform.position, new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized, ref velocity, smoothTime);
    }
}
