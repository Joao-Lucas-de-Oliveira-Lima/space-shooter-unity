using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FollowThePlayer : MonoBehaviour
{
    public Transform target;
    public float velocity = 5f;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        offset = this.transform.position - target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(this.transform.position, desiredPosition, velocity * Time.deltaTime);
        this.transform.position = smoothedPosition;
    }
}
