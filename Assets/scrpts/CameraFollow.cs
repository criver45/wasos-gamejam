using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // El jugador al que seguirá la cámara
    public float minY = 0f; // Límite inferior de la cámara (mínimo Y)
    public float maxY = 5f; // Límite superior de la cámara (máximo Y)

    void Update()
    {
        // Seguimos al jugador, pero limitamos el movimiento en Y entre minY y maxY
        float clampedY = Mathf.Clamp(player.position.y, minY, maxY);
        transform.position = new Vector3(player.position.x, clampedY, transform.position.z);
    }
}