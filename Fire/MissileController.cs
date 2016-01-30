using UnityEngine;
using System.Collections;

public class MissileController : MonoBehaviour {

	public GameObject explosionFXPrefab;
	public float explodeRadius = 5f;
	public float shakeAmount = 0.1f;
	public int attackDamage;

	[HideInInspector]
	public GameObject target = null;
	public float timeToDestroy = 10f;

	Rigidbody2D rigidody2D;
	Mover mover;

	void Start(){
		rigidody2D = GetComponent<Rigidbody2D> ();
		mover = GetComponent<Mover> ();

		Destroy (gameObject, timeToDestroy);
	}

	/// <summary>
	/// Vérifie ce qui entre dans le percepts de l'agent.
	/// </summary>
	protected void OnTriggerEnter2D(Collider2D other){

		if(other.CompareTag("Enemy")){
			if (target != null) {
				if (Vector2.Distance (target.transform.position, transform.position) > Vector2.Distance (other.transform.position, transform.position)) {
					target = other.gameObject;
				}
			} else {
				
				target = other.gameObject;
			}

		}
	}

	protected void OnTriggerExit2D(Collider2D other){
		if(target == other.gameObject){
			target = null;
		}
	}

	void Update(){
		UpdateDirection ();

		if (target != null) {
			if (Vector2.Distance (target.transform.position, transform.position) < 1f) {
				Explode ();
			}
		}
	}

	void UpdateDirection(){
		if (target == null) {
			return;
		}

		mover.direction = target.transform.position - transform.position;

		float angle = Mathf.Atan2(mover.direction.y, mover.direction.x) * Mathf.Rad2Deg - 90;
		Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);

		transform.localRotation = q;

		rigidody2D.velocity = mover.direction.normalized * mover.speed;
	}

	void Explode(){
		if (explosionFXPrefab != null) {
			GameObject explosion = Instantiate (explosionFXPrefab, transform.position, Quaternion.identity) as GameObject;
			explosion.GetComponent<AudioSource> ().pitch = Random.Range (0.9f, 1.1f);
			Destroy (explosion, 10f);
		}

		iTween.ShakePosition (Camera.main.gameObject, iTween.Hash ("amount", new Vector3 (shakeAmount, shakeAmount, 0), "time", 1f));

		GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");
		foreach (GameObject enemy in enemies) {
			if (Vector2.Distance (transform.position, enemy.transform.position) < explodeRadius && !enemy.GetComponent<AgentLife>().isDead) {
				enemy.GetComponent<AgentLife> ().TakeDamage (attackDamage, Color.red);
			}
		}

		Destroy (gameObject);
	}
		
}
