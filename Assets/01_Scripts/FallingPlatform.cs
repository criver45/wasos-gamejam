using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float fallDelay = 0.5f; // Tiempo que tarda en caer el suelo despu�s de ser pisado
    private Rigidbody2D rb;
    private bool isFalling = false; // Para asegurarnos de que el suelo solo caiga una vez

    void Start()
    {
        // Asignamos el Rigidbody2D del suelo
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Verificamos si el jugador ha pisado el suelo y si a�n no ha comenzado a caer
        if (collision.gameObject.CompareTag("Player") && !isFalling)
        {
            isFalling = true; // Evitamos que se inicie la ca�da varias veces
            StartCoroutine(Fall()); // Inicia la ca�da despu�s de un peque�o retraso
        }
    }

    IEnumerator Fall()
    {
        // Esperamos el tiempo de retraso antes de caer
        yield return new WaitForSeconds(fallDelay);

        // Cambia el Body Type a Dynamic para que el suelo caiga
        rb.bodyType = RigidbodyType2D.Dynamic;
    }
}