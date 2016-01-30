using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TrailRenderer))]
public class AgentMovementDash : AgentMovement {

	public float timerToDash;
	public float dashForce;
	public Color dashColor;

	float timer = 0f;
	TrailRenderer trail;

	void Start(){
		trail = GetComponent<TrailRenderer> ();
		trail.material.color = dashColor;
	}

	protected override void GoToEnemy() {
		timer += Time.fixedDeltaTime;
		if (timer > timerToDash) {
			Dash ();
			timer = 0;
		}

		base.GoToEnemy ();
	}

	void Dash() {

		if (Random.Range (0, 2) == 0) {
			agentRigidbody.AddRelativeForce (Vector2.up * dashForce);
		} else {
			agentRigidbody.AddRelativeForce (Vector2.down * dashForce);
		}
	}
}
