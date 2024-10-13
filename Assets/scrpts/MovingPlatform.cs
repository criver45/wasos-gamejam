using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float moveSpeed = 2f; // Velocidad a la que se mueve la plataforma
    public float moveDistance = 3f; // Distancia que recorrerá de un lado a otro
    private Vector3 startPosition;
    private bool movingRight = true;

    void Start()
    {
        // Guardamos la posición inicial de la plataforma
        startPosition = transform.position;
    }

    void Update()
    {
        MovePlatform();
    }

    void MovePlatform()
    {
        // Verificamos si la plataforma debe moverse hacia la derecha o hacia la izquierda
        if (movingRight)
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime; // Mover a la derecha

            // Si la plataforma ha recorrido la distancia máxima, cambia de dirección
            if (transform.position.x >= startPosition.x + moveDistance)
            {
                movingRight = false;
            }
        }
        else
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime; // Mover a la izquierda

            // Si la plataforma ha vuelto al punto inicial (menos el rango), cambia de dirección
            if (transform.position.x <= startPosition.x - moveDistance)
            {
                movingRight = true;
            }
        }
    }
}
