using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FollowThePlayer : MonoBehaviour
{
    public GameObject player;
    public Transform target;
    public float velocity = 5f;
    public Vector3 offset;
    public float maxDistance = 3f; // Distância máxima entre a câmera e o jogador

    public Vector3 cameraOriginalPosition;

    public int controlador = 1;

    // Start is called before the first frame update
    void Start()
    {
        cameraOriginalPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (player != null && controlador == 1)
        {
            target = player.transform;
            offset = this.transform.position - target.transform.position;
            controlador = 0;
        }
        else if (player != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(this.transform.position, desiredPosition, velocity * Time.deltaTime);
            // Limitar a distância entre a câmera e o jogador
            Vector3 clampedPosition = target.position + Vector3.ClampMagnitude(smoothedPosition - target.position, maxDistance);
            this.transform.position = clampedPosition;
        }
        else
        {
            //if (this.transform.position != cameraOriginalPosition)
            //{
                //Vector3 smoothedPosition = Vector3.Lerp(this.transform.position, cameraOriginalPosition, velocity * Time.deltaTime);
                //this.transform.position = smoothedPosition;
            //}
            controlador = 1;
        }
    }
}