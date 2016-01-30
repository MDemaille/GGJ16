using UnityEngine;
using System.Collections;

/// <summary>
/// La classe AgentAttack définie les différentes méthodes permettant aux
/// agents d'attaquer.
/// </summary>

[RequireComponent(typeof(Agent))]
[RequireComponent(typeof(AgentMovement))]
[RequireComponent(typeof(AgentLife))]
public class AgentAttack : MonoBehaviour {
	
	public float timeBetweenAttacks = 0.5f;
	public int attackDamage = 10;
	public GameObject impactAttack; 

	protected Agent agent;
	protected AgentMovement myMovement;
	protected AgentLife myLife;

	protected float timer;
	
	void Awake ()
	{
		myLife = GetComponent<AgentLife>();
		myMovement = GetComponent<AgentMovement>();

		agent = GetComponent<Agent>();
	}

	/// <summary>
	/// Vérifie l'état de l'agent pour le faire attaquer.
	/// </summary>
	protected virtual void Update ()
	{
		timer += Time.deltaTime;

		if(agent.state == Agent.ATTACK){
			Attack();
		}
	}

	/// <summary>
	/// Vérifie si l'agent peut attaquer.
	/// </summary>
	/// <returns><c>true</c>, si le timer est vérifié, <c>false</c> sinon.</returns>
	public bool CheckTimer(){
		return (timer > timeBetweenAttacks);
	}
	
	/// <summary>
	/// Méthode d'attaque de l'agent.
	/// </summary>
	protected virtual AgentLife Attack ()
	{
		if(timer < timeBetweenAttacks || Vector3.Distance(myMovement.agentRigidbody.position, myMovement.target.transform.position) > myMovement.stoppingDistance || myLife.currentLife <= 0)
		{
			agent.state = Agent.WIGGLE;
			return null;
		}

		myMovement.agentRigidbody.velocity = Vector2.zero;

		timer = 0f;

		AgentLife enemyLife = myMovement.target.GetComponent<AgentLife>();
		if (enemyLife != null) {
			if (enemyLife.currentLife > 0) {
				enemyLife.TakeDamage (attackDamage);
				if (impactAttack != null) {
					Instantiate (impactAttack, myMovement.target.transform.position, Quaternion.identity);
				}
				
			}
		}

		if (enemyLife.currentLife <= 0) {
			agent.state = Agent.NONE;
		}

		return enemyLife;
	}
}
