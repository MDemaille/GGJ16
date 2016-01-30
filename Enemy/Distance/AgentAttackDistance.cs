using UnityEngine;
using System.Collections;

public class AgentAttackDistance : AgentAttack {

	public enum TypeShot { ONE_DIRECTION = 0, CONE = 1, CIRCLE = 2, RANDOM_CIRCLE = 3, RANDOM_CONE = 4 } 

	[System.Serializable]
	public class ConeAndCircleShot {
		public int nbShots;
		public float angle;
	}

	[System.Serializable]
	public class RandomShot {
		public float inaccuracy;
	}

	public GameObject shotPrefab;
	public float shotSpeed;
	public float shotScale;
	public ConeAndCircleShot coneAndCircleShot;
	public RandomShot randomShot;
	public Transform shotSpawn;

	public TypeShot typeShot;

	/// <summary>
	/// Méthode d'attaque de l'agent.
	/// </summary>
	protected override AgentLife Attack ()
	{
		Vector3 diff = myMovement.target.transform.position - transform.position;
		float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
		myMovement.agentRigidbody.rotation = rot_z;
		myMovement.agentRigidbody.velocity = Vector2.zero;

		if(timer < timeBetweenAttacks || Vector3.Distance(myMovement.agentRigidbody.position, myMovement.target.transform.position) > myMovement.stoppingDistance || myLife.currentLife <= 0)
		{
			agent.state = Agent.WIGGLE;
			return null;
		}

		timer = 0f;

		Shoot();

		return null;
	}

	/// <summary>
	/// Permet à l'agent de générer des anticorps.
	/// </summary>
	void Shoot(){

		Vector3 direction = myMovement.target.transform.position - transform.position;

		switch (typeShot) {
		case (TypeShot.ONE_DIRECTION):
			Fire.ShootDirection(shotSpawn, shotPrefab, direction, shotSpeed, shotScale, 0);
			break;

		case TypeShot.CONE:
			Fire.ShootCone(shotSpawn, shotPrefab, direction, coneAndCircleShot.nbShots, shotSpeed, coneAndCircleShot.angle, shotScale, 0);
			break;

		case TypeShot.CIRCLE:
			Fire.ShootCircle (shotSpawn, shotPrefab, coneAndCircleShot.nbShots, coneAndCircleShot.angle, shotSpeed, shotScale, 0); 
			break;

		case TypeShot.RANDOM_CIRCLE:
			Fire.ShootRandomCircle (shotSpawn, shotPrefab, myMovement.target.transform.position, coneAndCircleShot.nbShots, randomShot.inaccuracy, shotSpeed, shotScale, 0);
			break;

		case TypeShot.RANDOM_CONE:
			Fire.ShootRandomCone(shotSpawn, shotPrefab, myMovement.target.transform.position, coneAndCircleShot.nbShots, randomShot.inaccuracy, shotSpeed, shotScale, 0);
			break;
		}

	}

}
