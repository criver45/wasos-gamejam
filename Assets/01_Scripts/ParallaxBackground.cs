using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public Transform player; // El jugador que se mover�
    public float parallaxEffect = 0.5f; // Controla qu� tan r�pido se mover� el fondo en comparaci�n al jugador

    private Vector3 initialPosition;

    void Start()
    {
        // Guardamos la posici�n inicial del fondo
        initialPosition = transform.position;
    }

    void Update()
    {
        // Calculamos el movimiento parallax en el eje X basado en la posici�n del jugador
        float distance = (player.position.x * parallaxEffect);
        transform.position = new Vector3(initialPosition.x + distance, initialPosition.y, initialPosition.z);
    }
}
