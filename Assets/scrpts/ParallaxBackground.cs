using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public Transform player; // El jugador que se moverá
    public float parallaxEffect = 0.5f; // Controla qué tan rápido se moverá el fondo en comparación al jugador

    private Vector3 initialPosition;

    void Start()
    {
        // Guardamos la posición inicial del fondo
        initialPosition = transform.position;
    }

    void Update()
    {
        // Calculamos el movimiento parallax en el eje X basado en la posición del jugador
        float distance = (player.position.x * parallaxEffect);
        transform.position = new Vector3(initialPosition.x + distance, initialPosition.y, initialPosition.z);
    }
}
