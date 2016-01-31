using UnityEngine;
using System.Collections;

public class PouleManager : MonoBehaviour {

	public GameObject prefab;

	public int nbPouleToKill = 10;

	public float frequency = 2f;
	public float decreaseFrequency = 0.2f;
	public float radiusSpawn = 15f;

	float changeFrequency = 0f;
	int pouleKill = 0;

	bool finish = false;

	PlayerLife player;

	void Start(){
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerLife> ();;
		StartCoroutine (SpawnPoule ());
	}

	void Update(){
		if (player.isDead) {
			enabled = false;
		}

		/*changeFrequency += Time.deltaTime;
		if (changeFrequency > timeBetweenChangeFrequency) {
			if (frequency == 0.1f) {
				Stop ();
				return;
			}

			changeFrequency = 0f;
			frequency -= 0.1f;
		}*/
	}

	IEnumerator SpawnPoule(){
		while (true) {
			if (player.isDead) {
				yield break;
			}

			Vector2 pos = Random.insideUnitCircle * radiusSpawn;
			Instantiate (prefab, pos, Quaternion.identity);

			yield return new WaitForSeconds (frequency);
		}
	}

	void Stop(){
		StopCoroutine (SpawnPoule ());
		enabled = false;

		finish = true;
	}

	public void DeadPoule(){
		pouleKill++;
		if (pouleKill >= nbPouleToKill) {
			if (nbPouleToKill > 40) {
				Stop ();
				return;
			}

			pouleKill = 0;
			nbPouleToKill += 5;
			frequency -= decreaseFrequency;
		}
	}

	public bool waveFinish {
		get {
			return finish;
		}
	}
}
