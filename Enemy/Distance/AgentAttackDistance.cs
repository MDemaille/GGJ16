using UnityEngine;
using System.Collections;

public class AgentAttackDistance : AgentAttack {

	public enum TypeShot { ONE_DIRECTION = 0, CONE = 1, CIRCLE = 2, RANDOM_CIRCLE = 3, RANDOM_CONE = 4 } 

	public GameObject shotPrefab;
	public Transform shotSpawn;
	public Vector3 scale;

	public TypeShot typeShot;

	/// <summary>
	/// Méthode d'attaque de l'agent.
	/// </summary>
	protected override AgentLife Attack ()
	{
		if(timer < timeBetweenAttacks || Vector3.Distance(myMovement.agentRigidbody.position, myMovement.target.transform.position) > myMovement.stoppingDistance || myLife.currentLife <= 0)
		{
			agent.state = Agent.WIGGLE;
			return null;
		}

		timer = 0f;

		Fire();

		return null;
	}

	/// <summary>
	/// Permet à l'agent de générer des anticorps.
	/// </summary>
	void Fire(){
		//TODO
		switch (typeShot) {
		case TypeShot.ONE_DIRECTION:
			break;

		case TypeShot.CONE:
			break;

		case TypeShot.CIRCLE:
			break;

		case TypeShot.RANDOM_CIRCLE:
			break;

		case TypeShot.RANDOM_CONE:
			break;
		}

	}

}
