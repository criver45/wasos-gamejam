using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchingObstacle : MonoBehaviour
{
    public float waitTime = 0.5f; // Tiempo que el jugador debe estar sobre el obst�culo antes de lanzarlo
    public float launchForce = 10f; // Fuerza con la que el obst�culo y el jugador volar�n hacia arriba
    private bool isPlayerOnTop = false;
    private Rigidbody2D rb;
    private GameObject player; // Referencia al jugador

    void Start()
    {
        // Asignamos el Rigidbody2D del obst�culo y lo configuramos como Kinematic inicialmente
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic; // Evitar que el obst�culo se mueva antes del lanzamiento
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Detectamos que el jugador est� sobre el obst�culo
            isPlayerOnTop = true;
            player = collision.gameObject; // Guardamos la referencia al jugador
            StartCoroutine(WaitAndLaunch()); // Comenzamos la cuenta atr�s para el lanzamiento
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // Si el jugador sale del obst�culo antes del tiempo, cancelamos el lanzamiento
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerOnTop = false;
        }
    }

    IEnumerator WaitAndLaunch()
    {
        // Esperamos el tiempo especificado
        yield return new WaitForSeconds(waitTime);

        if (isPlayerOnTop) // Si el jugador sigue sobre el obst�culo, lanzamos ambos
        {
            // Cambiamos el tipo de cuerpo del obst�culo a Dynamic para que la f�sica lo afecte
            rb.bodyType = RigidbodyType2D.Dynamic;

            // Aplicamos la fuerza hacia arriba al obst�culo
            rb.AddForce(Vector2.up * launchForce, ForceMode2D.Impulse);

            // Tambi�n aplicamos una fuerza al jugador para que sea lanzado junto con el obst�culo
            Rigidbody2D playerRb = player.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                playerRb.AddForce(Vector2.up * launchForce, ForceMode2D.Impulse);
            }
        }
    }
}
