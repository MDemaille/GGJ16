﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// La classe AgentMovement permet de déplacer l'agent.
/// </summary>

[RequireComponent(typeof(Agent))]
[RequireComponent(typeof(Rigidbody2D))]
public class AgentMovement : MonoBehaviour {

	public float speed;
	public float wiggle;
	public float distanceToFollow;
	public float stoppingDistance;

	protected Agent agent;

	[HideInInspector] public GameObject target;
	[HideInInspector] public Rigidbody2D agentRigidbody;


	float timerToFlee = 0f;
	AgentAttackToxic agentToxic;

	/// <summary>
	/// Initialise la classe.
	/// </summary>
	void Awake () {
		agentRigidbody = GetComponent<Rigidbody2D>();
		agent = GetComponent<Agent>();

		agentToxic = GetComponent<AgentAttackToxic> ();

		target = GameObject.FindGameObjectWithTag("Player");

		if (target == null) {
			Debug.LogError ("Player not found !");
		}
	}
	
	/// <summary>
	/// Vérifie l'état de l'agent et clamp sa position.
	/// </summary>
	protected virtual void FixedUpdate () {
		
		if(agent.state == Agent.WIGGLE){
			Wiggle();
		}else if(agent.state == Agent.GOTOENEMY){
			GoToEnemy();
		}else if(agent.state == Agent.FLEE){
			Flee();
		}
	}

	/// <summary>
	/// Déplacer l'agent vers l'ennemi le plus proche.
	/// </summary>
	protected virtual void GoToEnemy(){
		if (target == null) {
			agentRigidbody.velocity = Vector2.zero;
			agent.state = Agent.NONE;
			return;
		}

		if(Vector2.Distance(agentRigidbody.position, target.transform.position) < distanceToFollow){

			if(Vector3.Distance(agentRigidbody.position, target.transform.position) < stoppingDistance){
				agentRigidbody.velocity = Vector2.zero;
				agent.state = Agent.ATTACK;
				return;
			}

			Vector3 diff = target.transform.position - transform.position;
			
			float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

			agentRigidbody.rotation = rot_z;
			agentRigidbody.velocity = new Vector2(transform.right.x, transform.right.y) * speed * Time.fixedDeltaTime;
		}else{
			agent.state = Agent.WIGGLE;
			return;
		}
	}

	/// <summary>
	/// Permet de faire avancer l'agent.
	/// </summary>
	protected virtual void Wiggle(){
		if (target == null) {
			agentRigidbody.velocity = Vector2.zero;
			agent.state = Agent.NONE;
			return;
		}

		if(Vector2.Distance(agentRigidbody.position, target.transform.position) < distanceToFollow){
			agent.state = Agent.GOTOENEMY;
			return;
		}

		// Faire avancer l'agent
		agentRigidbody.rotation += Random.Range(-wiggle,wiggle);
		agentRigidbody.velocity = new Vector2(transform.right.x, transform.right.y) * speed * Time.deltaTime;
	}

	/// <summary>
	/// Permet à l'agent de fuir face à l'ennemi
	/// </summary>
	protected virtual void Flee(){
		if (target == null) {
			agentRigidbody.velocity = Vector2.zero;
			agent.state = Agent.NONE;
			return;
		}

		if (agentToxic == null) {
			agent.state = Agent.WIGGLE;
			return;
		}

		timerToFlee += Time.deltaTime;

		if(timerToFlee < agentToxic.toxicDuration){

			Vector3 diff = target.transform.position - transform.position;

			float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

			agentRigidbody.rotation = rot_z + 180f;
			agentRigidbody.velocity = new Vector2(transform.right.x, transform.right.y) * speed * Time.deltaTime;
		}else{
			timerToFlee = 0f;

			agent.state = Agent.WIGGLE;
			return;
		}
	}
}
