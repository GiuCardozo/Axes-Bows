using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Transform player2;

    public float yDistance = 6f;
    public float yMovement = 12f;

    public float xDistance = 11f;
    public float xMovement = 22f;

    public Vector3 cameraOrigin;
    public Vector3 cameraDestination;

    public float movementTime = 0.5f;
    public bool isMoving;

    
    void Start()
    {
        //player = FindObjectOfType<PJ1Movement>().transform;
    }

    
    void Update()
    {
        if (!isMoving)
        {
            if (player.position.y - transform.position.y >= yDistance && player2.position.y - transform.position.y >= yDistance) //si ambos jugadores se encuentran en determinada posicion, la cámara se desplaza
            {
                cameraDestination += new Vector3(0, yMovement, 0);
                StartCoroutine(MoveCamera());
            }
            else if (transform.position.y - player.position.y >= yDistance && transform.position.y - player2.position.y >= yDistance)
            {
                cameraDestination -= new Vector3(0, yMovement, 0);
                StartCoroutine(MoveCamera());
            }
            else if (player.position.x - transform.position.x >= xDistance && player2.position.x - transform.position.x >= xDistance)
            {
                cameraDestination += new Vector3(xMovement, 0, 0);
                StartCoroutine(MoveCamera());
            }
            else if (transform.position.x - player.position.x >= xDistance && transform.position.x - player2.position.x >= xDistance)
            {
                cameraDestination -= new Vector3(xMovement, 0, 0);
                StartCoroutine(MoveCamera());
            }
        }
    }

    IEnumerator MoveCamera()
    {
        isMoving = true;
        var currentPos = transform.position;
        var t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / movementTime;
            transform.position = Vector3.Lerp(currentPos, cameraDestination, t);
            transform.position = new Vector3(transform.position.x, transform.position.y, currentPos.z);
            yield return null;
        }
        isMoving = false;
    }
}
