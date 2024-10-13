using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPowerUp : MonoBehaviour
{
    public float moveSpeed = 2f; // Velocidad de movimiento del fantasma
    private Transform player; // Referencia al jugador
    private Rigidbody2D rb;

    void Start()
    {
        // Buscar al jugador por su tag "Player"
        player = GameObject.FindGameObjectWithTag("Player").transform;

        rb = GetComponent<Rigidbody2D>();

        // Congelar la rotación en el eje Z para evitar que el fantasma ruede
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        // Asignamos el Rigidbody2D para controlar la gravedad y el movimiento físico
        rb = GetComponent<Rigidbody2D>();
        if (player == null)
        {
            Debug.LogError("No se encontró ningún objeto con el Tag 'Player'");
        }
    }

    void Update()
    {
        if (player != null)
        {
            FollowPlayer(); // Seguir al jugador en cada frame
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
        // Si el fantasma toca al jugador
        if (collision.gameObject.CompareTag("Player"))
        {
            Player playerScript = collision.gameObject.GetComponent<Player>();
            if (playerScript != null)
            {
                // Aplicar el efecto de crecimiento y aumento de gravedad
                playerScript.GrowAndIncreaseGravity();
            }

            // Destruir el fantasma después de aplicar el efecto
            Destroy(gameObject);
        }
    }
}
