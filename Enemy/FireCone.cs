using UnityEngine;
using System.Collections;

public class FireCone : MonoBehaviour 
{
	
	public int[] nbShot = {3};
	public bool loopOnNbShots = true;
	private int indexNbShot = 0;
	private int lengthNbShot;

	public GameObject shot;

	public Transform shotSpawn;
	
	public float bulletSpeed = 10.0f;
	
	
	public float fireRate = 0.2f;
	private float nextFire;
	
	public int maxMunitions = 1;
	private int munitions  = 5;
	
	public float reloadTime = 1.5f;
	private float nextReload;

	public float angle = 180;

	public float bulletScale = 1.0f;
	
	public float firstFire;

	public Vector2 fireDirection;

	public bool ShootPlayer;

    public float range = 50;

	void Start () {
		lengthNbShot = nbShot.GetLength (0);
		nextFire = Time.time + firstFire;
		munitions = maxMunitions;
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		ShootCone ();
	}

	void ShootCone()
	{

        if (GameManager.player == null)
            return;

		//On Check le rechargement
		if (munitions == 0 && Time.time > nextReload) 
		{
			munitions = maxMunitions;
		}
		
		if (Time.time > nextFire  && munitions > 0 && Vector2.Distance(transform.position, GameManager.player.transform.position) <= range) 
		{
			Debug.Log("Allo");
			nextFire = Time.time + fireRate;




                 Vector3 playerPosition = GameManager.player.transform.position;
				
				//On retrouve la position du player grace à son tag

				if(ShootPlayer)
				{
					fireDirection = playerPosition - shotSpawn.position;
					fireDirection.Normalize();
				}
				

				Fire.ShootCone(shotSpawn,shot, fireDirection ,nbShot[indexNbShot],bulletSpeed,angle, bulletScale,0); 
	

				//Boucle sur les variations
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
