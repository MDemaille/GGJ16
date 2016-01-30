using UnityEngine;
using System.Collections;

public class AgentAttackToxic : AgentAttack {

	public int damagePerSecond;
	public int toxicDuration;

	public bool flee;

	void Start(){
		timeBetweenAttacks = toxicDuration + 1f;
	}

	protected override AgentLife Attack ()
	{
		AgentLife enemyLife = base.Attack ();
		if(enemyLife != null){
			if (enemyLife.currentLife > 0) {
				StartCoroutine (ToxicDamage (enemyLife));

				if (flee) {
					agent.state = Agent.FLEE;
				}
			}
		}

		return enemyLife;
	}

	IEnumerator ToxicDamage(AgentLife enemyLife){
		yield return new WaitForSeconds (0.5f);

		for(int i = 0 ; i < toxicDuration ; i++) {
			if (enemyLife == null) {
				yield break;
			}
			enemyLife.TakeDamage (damagePerSecond, Color.green);
			yield return new WaitForSeconds (1f);
		}
	}
}
