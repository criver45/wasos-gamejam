using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using static Enemy;

public class Spawner : MonoBehaviour
{
    [Header("Estadisticas")]
    public float timeEnemySpawn = 1f;
    public float timeBtwSpawn = 2f;
    [Header("Referencias")]
    public Transform spawnPoint;
    public List<GameObject> enemies = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeBtwSpawn += Time.deltaTime;

        if(timeBtwSpawn >= timeEnemySpawn)
        {
            timeBtwSpawn = 0f;
            CreateEnemy();
        }
    }

    void CreateEnemy()
    {
        int typeEnemy = Random.Range(0, enemies.Count);
        Vector2 newPosition = new Vector2(transform.position.x, transform.position.y);
        Instantiate(enemies[typeEnemy], newPosition, Quaternion.identity);
    }
}
