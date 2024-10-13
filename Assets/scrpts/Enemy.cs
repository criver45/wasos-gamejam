using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Para manejar el cambio de escena

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 2f; // Velocidad del enemigo
    private Rigidbody2D rb;
    private bool movingRight = true; // Controla la dirección del enemigo

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Asignar el Rigidbody2D
        rb.constraints = RigidbodyConstraints2D.FreezeRotation; // Congelar la rotación en Z para que no gire
    }

    void Update()
    {
        Move(); // Llamamos al movimiento en cada frame
    }

    void Move()
    {
        // Mover al enemigo a la derecha o izquierda dependiendo de la dirección
        if (movingRight)
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y); // Movimiento a la derecha
        }
        else
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y); // Movimiento a la izquierda
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Si el enemigo colisiona con un obstáculo, cambia de dirección
        if (collision.gameObject.CompareTag("Ground"))
        {
            movingRight = !movingRight; // Cambiamos la dirección al chocar
            Flip(); // Giramos el sprite del enemigo para que mire hacia la nueva dirección
        }

        // Si el enemigo toca al jugador, el jugador muere y se reinicia el juego
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("MainPrincipal"); // Reinicia la escena (reemplaza con el nombre de tu escena principal)
        }
    }

    void Flip()
    {
        // Invertimos la escala en X para que el sprite gire hacia la nueva dirección
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
