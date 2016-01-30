using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {
    public GameObject player;
    public float distanceMaxFromPlayer = 30f;
    public int nbMaxEnemies = 10;

    private int nbEnemies = 0;
	
	void FixedUpdate () {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        nbEnemies = enemies.Length;

        for (int i = 0; i < enemies.Length; ++i)
        {
            if (Vector2.Distance(enemies[i].transform.position, player.transform.position) >= distanceMaxFromPlayer)
            {
                Destroy(enemies[i]);
            }
        }
	}

    public bool canSpawnEnemies()
    {
        return nbEnemies < nbMaxEnemies;
    }
}
