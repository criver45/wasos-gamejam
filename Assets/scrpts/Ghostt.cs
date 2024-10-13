using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Ghostt : MonoBehaviour
{
    public float moveSpeed = 2f; // Velocidad de movimiento del fantasma
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Congelar la rotación en el eje Z para evitar que el fantasma ruede
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void Update()
    {
        // Hacemos que el fantasma se mueva hacia la izquierda
        MoveLeft();
    }

    void MoveLeft()
    {
        rb.velocity = new Vector2(-moveSpeed, rb.velocity.y); // Movimiento constante hacia la izquierda
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Si el fantasma toca al jugador, lo enviamos a la escena principal
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("MainPrincipal"); // Asegúrate de que esta sea la escena correcta
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Si el fantasma toca el trigger de desaparición
        if (other.CompareTag("Disappear"))
        {
            Destroy(gameObject); // Destruir el fantasma al tocar el trigger
        }
    }
}