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
        Vector2 movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rigidbody.MovePosition(rigidbody.position + movement * speed * Time.fixedDeltaTime);
    }
}
