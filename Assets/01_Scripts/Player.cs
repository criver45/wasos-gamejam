using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("Estadistics")]
    public float speed = 5f;
    public float jumpForce = 12f;
    public bool canJump = true;

    [Header("References")]
    public Rigidbody2D rb;
    public Animator animBody;

    private Vector3 originalScale; // Guardar el tamaño original del jugador
    private float originalGravityScale; // Guardar el valor original de la gravedad

    // Start is called before the first frame update
    void Start()
    {
        originalScale = transform.localScale; // Guardar el tamaño original
        originalGravityScale = rb.gravityScale; // Guardar la gravedad original
        animBody.SetBool("Grounded", true); // Inicializamos con el jugador en el suelo
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Mirror();
        Jump();
    }

    void Movement()
    {
        float x = Input.GetAxis("Horizontal");
        animBody.SetFloat("Speed", Mathf.Abs(x));
        rb.velocity = new Vector2(x * speed, rb.velocity.y); // Movimiento en el eje X
    }

    void Mirror()
    {
        // Invertimos la dirección del sprite según el movimiento del jugador
        if (rb.velocity.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (rb.velocity.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    void Jump()
    {
        if (canJump)
        {
            // Saltar cuando se presiona la barra espaciadora, UpArrow o W
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); // Aplicamos la fuerza del salto
                canJump = false;
                animBody.SetBool("Grounded", false);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Verificamos si el jugador está tocando el suelo
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true; // Permitimos que el jugador pueda saltar nuevamente
            animBody.SetBool("Grounded", true); // Actualizamos la animación
        }

        // Si el jugador cae en una zona marcada como "Void", reiniciamos el juego
        if (collision.gameObject.layer == LayerMask.NameToLayer("Void"))
        {
            Destroy(gameObject); // El jugador muere si cae al vacío
            SceneManager.LoadScene("MainPrincipal"); // Reiniciar el juego cargando la escena principal
        }
    }

    public void GrowAndIncreaseGravity()
    {
        // Aumentar el tamaño del jugador (puedes ajustar este valor)
        transform.localScale = originalScale * 1.5f;

        // Aumentar la gravedad del jugador para que no salte tan alto
        rb.gravityScale = originalGravityScale * 3f;

        // También puedes reducir el jumpForce si quieres un control más preciso
        jumpForce *= 0.75f; // Reduce el salto para que sea menor después de crecer
    }
}
