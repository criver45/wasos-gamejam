using UnityEngine;

public class OrcShamanController : MonoBehaviour
{
    public float walkSpeed = 3f;
    public float runSpeed = 6f;
    public float jumpForce = 7f;

    private float moveSpeed;
    private bool isGrounded;
    private Animator animator;
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        animator = GetComponent<Animator>();  // Asegúrate de que el Animator esté correctamente asignado
        rb = GetComponent<Rigidbody2D>();     // El Rigidbody2D también debe estar presente en el personaje
        moveSpeed = walkSpeed;                // Inicialmente el personaje camina
    }

    void Update()
    {
        // Movimiento horizontal
        movement.x = Input.GetAxisRaw("Horizontal");

        // Si no está tocando el suelo, no puede caminar ni correr
        if (isGrounded)
        {
            // Controlar caminar o correr
            if (movement.x != 0)
            {
                if (Input.GetKey(KeyCode.LeftShift))  // Shift presionado: correr
                {
                    moveSpeed = runSpeed;
                    animator.SetBool("isRunning", true);
                    animator.SetBool("isWalking", false);
                }
                else  // No Shift: caminar
                {
                    moveSpeed = walkSpeed;
                    animator.SetBool("isWalking", true);
                    animator.SetBool("isRunning", false);
                }
            }
            else  // Si no hay movimiento horizontal, Idle
            {
                animator.SetBool("isWalking", false);
                animator.SetBool("isRunning", false);
            }
        }

        // Controlar salto
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetTrigger("Jump");
            isGrounded = false;  // Hasta que aterrice, no puede saltar de nuevo
        }

        // Si el personaje está muerto, activar animación de muerte
        // Por ejemplo, si la salud llega a 0
        // if (health <= 0)
        // {
        //     animator.SetTrigger("isDead");
        // }
    }

    void FixedUpdate()
    {
        // Aplicar movimiento horizontal
        rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);
    }

    // Verificar si está tocando el suelo
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;  // Ahora el personaje puede caminar/correr/saltar
        }
    }

    // Verificar si dejó de tocar el suelo
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;  // Ya no está en el suelo, por lo tanto no puede saltar
        }
    }
}
