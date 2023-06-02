using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
    public float speed;
    void Start()
    {

    }
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = new Vector2(mousePosition.x - this.transform.position.x, mousePosition.y - this.transform.position.y);
        transform.up = direction;
        Debug.Log(direction);
        /*
        Vector3 difference = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position).normalized;
        float angle = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.Euler(0f, 0f, angle), speed * Time.deltaTime);
        //Quaternion rotation = Quaternion.Euler(0f, 0f, angle);
        this.transform.rotation = rotation;
        */
    }
}
