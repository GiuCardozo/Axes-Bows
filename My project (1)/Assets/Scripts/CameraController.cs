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

    void Update()
    {
        if (!isMoving)
        {
            // Verificar si ambos jugadores están activos
            bool isPlayerActive = player != null && player.gameObject.activeSelf;
            bool isPlayer2Active = player2 != null && player2.gameObject.activeSelf;

            if (isPlayerActive && isPlayer2Active)
            {
                // Movimiento de la cámara cuando ambos jugadores están vivos
                ControlCameraMovement(player.position, player2.position);
            }
            else if (isPlayerActive)
            {
                // Movimiento de la cámara cuando solo player está vivo
                ControlCameraMovement(player.position, player.position);
            }
            else if (isPlayer2Active)
            {
                // Movimiento de la cámara cuando solo player2 está vivo
                ControlCameraMovement(player2.position, player2.position);
            }
        }
    }

    void ControlCameraMovement(Vector3 pos1, Vector3 pos2)
    {
        if (pos1.y - transform.position.y >= yDistance && pos2.y - transform.position.y >= yDistance)
        {
            cameraDestination += new Vector3(0, yMovement, 0);
            StartCoroutine(MoveCamera());
        }
        else if (transform.position.y - pos1.y >= yDistance && transform.position.y - pos2.y >= yDistance)
        {
            cameraDestination -= new Vector3(0, yMovement, 0);
            StartCoroutine(MoveCamera());
        }
        else if (pos1.x - transform.position.x >= xDistance && pos2.x - transform.position.x >= xDistance)
        {
            cameraDestination += new Vector3(xMovement, 0, 0);
            StartCoroutine(MoveCamera());
        }
        else if (transform.position.x - pos1.x >= xDistance && transform.position.x - pos2.x >= xDistance)
        {
            cameraDestination -= new Vector3(xMovement, 0, 0);
            StartCoroutine(MoveCamera());
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
