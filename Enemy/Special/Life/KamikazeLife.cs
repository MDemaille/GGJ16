using UnityEngine;
using System.Collections;

public class KamikazeLife : AgentLife {

	protected override void Death ()
	{
		base.Death ();

		AgentAttackExplode agentAttack = GetComponent<AgentAttackExplode> ();

		GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");
		foreach (GameObject enemy in enemies) {

			if (enemy.gameObject != gameObject) {
				if (Vector2.Distance (transform.position, enemy.transform.position) < agentAttack.explodeRadius && !enemy.GetComponent<AgentLife>().isDead) {
					enemy.GetComponent<AgentLife> ().TakeDamage (agentAttack.attackDamage, Color.red);
				}
			}
		}

		GameObject[] boss = GameObject.FindGameObjectsWithTag ("Boss");
		foreach (GameObject b in boss) {

			if (Vector2.Distance (transform.position, b.transform.position) < agentAttack.explodeRadius && !b.GetComponent<AgentLife>().isDead) {
				b.GetComponent<AgentLife> ().TakeDamage (agentAttack.attackDamage, Color.red);
			}
		}

		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		if (Vector2.Distance (transform.position, player.transform.position) < agentAttack.explodeRadius) {
			player.GetComponent<AgentLife> ().TakeDamage (agentAttack.attackDamage, Color.red);
		}

		GetComponent<AgentAttackExplode> ().StartExplosion ();
	}
}
