using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smoothedMovimentation : MonoBehaviour
{
    public Vector3 targetPosition;
    public Vector3 offset;
    public float velocity = 5f;
    // Start is called before the first frame update
    void Start()
    {   
    }

    // Update is called once per frame
    void Update()
    {
        targetPosition = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        offset = this.transform.position + targetPosition;
        Vector3 desiredPosition = targetPosition + offset;
        Vector3 smoothedPosition = Vector3.Lerp(this.transform.position, desiredPosition, velocity * Time.deltaTime);
        this.transform.position = smoothedPosition;
    }
}
