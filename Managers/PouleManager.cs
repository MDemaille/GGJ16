using UnityEngine;
using System.Collections;

public class PouleManager : MonoBehaviour {

	public GameObject prefab;

	public float timeBetweenChangeFrequency = 5f;
	public float frequency = 2f;
	public float decreaseFrequency = 0.2f;
	public float radiusSpawn = 15f;

	float changeFrequency = 0f;

	bool finish = false;

	void Start(){
		StartCoroutine (SpawnPoule ());
	}

	void Update(){
		changeFrequency += Time.deltaTime;
		if (changeFrequency > timeBetweenChangeFrequency) {
			if (frequency == 0.1f) {
				Stop ();
				return;
			}

			changeFrequency = 0f;
			frequency -= 0.1f;
		}
	}

	IEnumerator SpawnPoule(){
		while (true) {
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

	public bool waveFinish {
		get {
			return finish;
		}
	}
}
