using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System;


public class FireCircle : MonoBehaviour 
{

	private GameObject gameManager;


	public int[] nbShot = {10};
	public bool loopOnNbShots = true;
	private int indexNbShot = 0;
	private int lengthNbShot;

	public GameObject shot;
	//On met un Shotspawn, que l'on pourra faire tourner, qui sait !
	public Transform shotSpawn;

	public bool turning = false;
	public float speedRotation = 1.0f;

	public float bulletSpeed = 10.0f;


	public float fireRate = 0.2f;
	private float nextFire;

	public int maxMunitions = 1;
	private int munitions  = 5;

	public float reloadTime = 1.5f;
	private float nextReload;

	public float firstFire;

	public float scale = 1.0f;

    public int damageModifier = 0;

    public float range = 50;
	

	// Use this for initialization
	void Start () {
		lengthNbShot = nbShot.GetLength (0);
		nextFire = Time.time + firstFire;
		munitions = maxMunitions;
	}
	
	// Update is called once per frame
	void Update () 
	{
		ShootCircle ();
	}
	

	void ShootCircle()
	{

        if (GameManager.player == null)
            return;

        //On Check le rechargement
        if (munitions == 0 && Time.time > nextReload) 
		{
			//Recharge et cible
			munitions = maxMunitions;

			if (turning)
			{
				shotSpawn.transform.Rotate(new Vector3(0,0,speedRotation));
			}
	
		}

        if (GameManager.player == null)
            return;

		if (Time.time > nextFire  && munitions > 0 && Vector2.Distance(transform.position, GameManager.player.transform.position) <= range ) 
		{
			
			nextFire = Time.time + fireRate;

			Fire.ShootCircle(shotSpawn,shot, nbShot[indexNbShot], 0, bulletSpeed, scale, 0);
			//SongManager.PlayOneShotEvent("event:/EnnemyShots/EnnemyShotConeOrCircle");
			indexNbShot++;
			if(indexNbShot == lengthNbShot)
			{
				if(loopOnNbShots)
					indexNbShot = 0;
				else
					indexNbShot = lengthNbShot -1;
			}

			//On enlève une munition
			munitions -= 1;
			if(munitions == 0)
			{
				nextReload = Time.time + reloadTime;
			}

			
		}

	}
}
