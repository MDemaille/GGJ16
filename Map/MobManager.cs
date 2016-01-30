using UnityEngine;
using System.Collections;

public class MobManager : MonoBehaviour {
    public MobWave lvl1_spawn;
    public MobWave lvl2_chicks;
    public MobWave lvl3_wings;

    float nextPop = 10f;
    float timeSinceLastPop = 0f;

	// Use this for initialization
	void Start () {
        spawnMonsters();
        timeSinceLastPop = 0f;
    }
	
	// Update is called once per frame
	void Update () {
        timeSinceLastPop += Time.deltaTime;

        if (timeSinceLastPop > nextPop)
        {
            spawnMonsters();
            timeSinceLastPop = 0f;
        }
    }

    void spawnMonsters()
    {
        // récupérer la zone du joueur
        float distance = System.Math.Abs(Vector2.Distance(new Vector2(), transform.position));
        MobWave wave = null;

        if (distance < 10f) { // Level 1 - Spawn
            wave = lvl1_spawn;
        }
        else if (distance < 20f) { // Level 2 - Chicks
            wave = lvl2_chicks;
        }
        else if (distance < 30f) { // Level 3 - Wings
            wave = lvl3_wings;
        }
        else
        {
            Debug.Log("Trop loin!");
            wave = lvl1_spawn;
        }

        nextPop = wave.timeBetweenPops;

        // instancier en fonction de la zone du joueur

        // L'origine pourrait etre aléatoire autour du joueur
        float angleDegrees = Random.Range(0, 360);
        float angleRadians = angleDegrees * Mathf.PI / 180.0f;
        float radius = 13f;

        Vector2 origin = transform.position;
        origin.x += radius * Mathf.Cos(angleRadians);
        origin.x += radius * Mathf.Sin(angleRadians);

        int nbMobs = Random.Range(wave.nbMobsMin, wave.nbMobsMax);

        for (int i = 0; i < nbMobs; ++i)
            spawnMob(wave.mobs[Random.Range(0, wave.mobs.Length)], origin, new Vector2(5, 4));
        
    }

    void spawnMob(GameObject mob, Vector2 origin, Vector2 size)
    {
        Vector2 pos = new Vector2(Random.Range(0, size.x), Random.Range(0, size.y));
        Instantiate(mob, origin + pos, new Quaternion());
    }
}
