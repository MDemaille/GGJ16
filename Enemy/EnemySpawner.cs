using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
    public EnemyManager enemyManager;
    public Vector2 size = new Vector2(5, 5);
    public GameObject[] enemies;
    public int minNbEnemies = 3;
    public int maxNbEnemies = 4;
    public float distanceFromPlayer = 15f;
    public GameObject player;

    public float timeBetweenSpawns = 5f;
    float timeSinceLastSpawn = 0f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn > timeBetweenSpawns)
        {
            if (Vector2.Distance(transform.position, player.transform.position) < distanceFromPlayer)
                if (enemyManager.canSpawnEnemies())
                    spawnEnemies();
            
            timeSinceLastSpawn = 0f;
        }
    }

    void spawnEnemies()
    {
        int nbEnemies = Random.Range(minNbEnemies, maxNbEnemies);
        for (int i = 0; i < nbEnemies; ++i)
        {
            Instantiate(enemies[Random.Range(0, enemies.Length)], transform.position + new Vector3(Random.Range(0, size.x), Random.Range(0, size.y), 0), new Quaternion());
        }
    }
}
