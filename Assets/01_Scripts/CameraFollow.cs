using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // El jugador al que seguir� la c�mara
    public float minY = 0f; // L�mite inferior de la c�mara (m�nimo Y)
    public float maxY = 5f; // L�mite superior de la c�mara (m�ximo Y)

    void Update()
    {
        // Seguimos al jugador, pero limitamos el movimiento en Y entre minY y maxY
        float clampedY = Mathf.Clamp(player.position.y, minY, maxY);
        transform.position = new Vector3(player.position.x, clampedY, transform.position.z);
    }
}