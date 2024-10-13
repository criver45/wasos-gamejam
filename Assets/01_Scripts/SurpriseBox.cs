using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurpriseBox : MonoBehaviour
{
    public enum SurpriseType { Coin, Ghost }; // Enum para decidir si es moneda o fantasma
    public SurpriseType surprise; // Tipo de sorpresa para este cubo

    public Sprite spriteAfterHit; // Sprite del cubo después de ser golpeado
    public Sprite spriteBeforeHit; // Sprite del cubo antes de ser golpeado
    public GameObject coinPrefab; // Prefab de la moneda
    public GameObject ghostPrefab; // Prefab del fantasma
    public Transform spawnPoint; // Punto donde aparecerá la sorpresa
    public float disappearDelay = 2f; // Tiempo antes de que la moneda o fantasma desaparezca (opcional para moneda)

    private bool hasBeenHit = false; // Controla si el cubo ya ha sido golpeado
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = spriteBeforeHit; // Inicializamos con el sprite antes de ser golpeado
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Verificamos si el jugador golpea el cubo desde abajo y si no ha sido golpeado antes
        if (collision.gameObject.CompareTag("Player") && !hasBeenHit)
        {
            if (collision.contacts[0].normal.y > 0)
            {
                ChangeSprite();
                StartCoroutine(SpawnSurprise()); // Generar la sorpresa según el tipo
            }
        }
    }

    void ChangeSprite()
    {
        spriteRenderer.sprite = spriteAfterHit;
        hasBeenHit = true; // Aseguramos que no se pueda golpear dos veces
    }

    IEnumerator SpawnSurprise()
    {
        GameObject surpriseObject = null;

        // Dependiendo del tipo de sorpresa, generamos moneda o fantasma
        if (surprise == SurpriseType.Coin)
        {
            surpriseObject = Instantiate(coinPrefab, spawnPoint.position, Quaternion.identity);
            // Esperar antes de desaparecer (solo para monedas)
            yield return new WaitForSeconds(disappearDelay);
            Destroy(surpriseObject);
        }
        else if (surprise == SurpriseType.Ghost)
        {
            Instantiate(ghostPrefab, spawnPoint.position, Quaternion.identity);
        }
    }
}
