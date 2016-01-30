using UnityEngine;
using System.Collections;

public class AgentAttackExplode : AgentAttack {

	public GameObject explosionFXPrefab;
	public float shakeAmount = 20;

	protected override AgentLife Attack(){
		AgentLife agentLife = base.Attack();
		Explode();

		return agentLife;
	}

	void Explode(){

		GameObject explosion = Instantiate(explosionFXPrefab, transform.position, Quaternion.identity) as GameObject;
		explosion.GetComponent<AudioSource>().pitch = Random.Range(0.9f,1.1f);
		Destroy(explosion, 10f);

		iTween.ShakePosition (Camera.main.gameObject, iTween.Hash ("amount", new Vector3 (shakeAmount, shakeAmount, 0), "time", 1f));

		myLife.currentLife = 0;
		myLife.Kill();
	}
}
