using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpawner : MonoBehaviour
{
    public GameObject ghostPrefab; // Prefab del fantasma
    public Transform spawnPoint; // Punto donde se generarán los fantasmas
    public float spawnInterval = 3f; // Intervalo de tiempo para generar fantasmas

    void Start()
    {
        // Comenzamos la generación de fantasmas
        StartCoroutine(SpawnGhosts());
    }

    IEnumerator SpawnGhosts()
    {
        while (true) // Bucle infinito para generar fantasmas cada cierto tiempo
        {
            SpawnGhost();
            yield return new WaitForSeconds(spawnInterval); // Esperamos el intervalo antes de generar otro fantasma
        }
    }

    void SpawnGhost()
    {
        // Instanciamos un nuevo fantasma en el punto de spawn
        GameObject ghost = Instantiate(ghostPrefab, spawnPoint.position, Quaternion.identity);
    }
}
