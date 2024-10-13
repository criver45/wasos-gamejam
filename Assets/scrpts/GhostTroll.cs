using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GhostTroll : MonoBehaviour
{
    public float moveSpeed = 2f; // Velocidad de movimiento del fantasma
    private Transform player; // Referencia al jugador
    private Rigidbody2D rb; // Para manejar la física del fantasma
    private bool stopFollowing = false; // Indica si el fantasma debe dejar de seguir al jugador

    void Start()
    {
        // Buscar al jugador por su tag "Player"
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Asignamos el Rigidbody2D para controlar la gravedad y el movimiento físico
        rb = GetComponent<Rigidbody2D>();

        // Congelar la rotación en el eje Z para que no gire
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        if (player == null)
        {
            Debug.LogError("No se encontró ningún objeto con el Tag 'Player'");
        }
    }

    void Update()
    {
        if (player != null && !stopFollowing)
        {
            FollowPlayer(); // Seguir al jugador solo si no ha colisionado con un obstáculo
        }
    }

    void FollowPlayer()
    {
        // Mover el fantasma hacia la posición del jugador horizontalmente
        Vector2 direction = (player.position - transform.position).normalized;
        rb.velocity = new Vector2(direction.x * moveSpeed, rb.velocity.y); // Aplicar velocidad en X, pero respetar la gravedad en Y
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Si el fantasma toca al jugador, termina el juego y cambia de escena
        if (collision.gameObject.CompareTag("Player"))
        {
            // Cambiar a otra escena (iniciar el juego desde el principio)
            SceneManager.LoadScene("MainPrincipal"); // Aquí reemplaza "MainScene" por el nombre de tu escena principal
        }

        // Si el fantasma choca con un obstáculo, dejar de seguir al jugador
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            stopFollowing = true; // Dejar de perseguir al jugador
            rb.velocity = Vector2.zero; // Detener el movimiento del fantasma
        }
    }
}