using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Fire : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void ShootDirection(Transform shotSpawn, GameObject shot, Vector2 direction, float speed, float scale, int damageUp)
	{
		GameObject tempShot = Instantiate(shot, shotSpawn.position, shotSpawn.rotation) as GameObject;
		tempShot.transform.localScale *= scale;
		tempShot.GetComponent<Mover>().direction = direction;
		tempShot.GetComponent<Mover>().speed = speed;
        tempShot.GetComponent<Shot>().damage += damageUp;
	}

	public static void ShootRandomCone(Transform shotSpawn, GameObject shot, Vector2 direction, int nbShots, float inaccuracy ,float speed, float scale, int damageUp)
	{

		for (int i = 0; i < nbShots; i++) 
		{

			Vector2 Sdirection = direction + UnityEngine.Random.insideUnitCircle * inaccuracy; 
			Sdirection.Normalize();

			float angle = Mathf.Atan2 (Sdirection.y, Sdirection.x) * Mathf.Rad2Deg + 180 ;
			Quaternion q = Quaternion.AngleAxis (angle, Vector3.forward);

			
			GameObject tempShot = Instantiate (shot, shotSpawn.position, q) as GameObject;
			tempShot.transform.localScale *= scale;
			tempShot.GetComponent<Mover> ().direction = Sdirection;
			tempShot.GetComponent<Mover> ().speed = speed;
            tempShot.GetComponent<Shot>().damage += damageUp;
        }



	}

	//Tire un cone à droite du shot spawn
	public static void ShootCone(Transform shotSpawn, GameObject shot, Vector2 direction, int nbShots, float speed, float angle, float scale, int damageUp)
	{
		direction.Normalize ();
		float angleCentre = Mathf.Atan2(direction.y, direction.x);
	
		angle *= Mathf.PI / 180;

		float interval;
		if (nbShots != 1)
			interval = angle / (nbShots - 1);
		else 
			interval = angle / nbShots;

	

		//de -angle/2 à +angle/2

		for (int i = 0; i<nbShots; i++) 
		{

			float currentAngle = (angleCentre - angle/2.0f) + i*interval;
			float x = Mathf.Cos(currentAngle);
			float y = Mathf.Sin(currentAngle);



			Quaternion q = Quaternion.AngleAxis (angle, Vector3.forward);

			GameObject tempShot = Instantiate(shot, shotSpawn.position, q) as GameObject;
			tempShot.transform.localScale *= scale;
			tempShot.GetComponent<Mover>().direction = new Vector2(x,y);
			tempShot.GetComponent<Mover>().speed = speed;
            tempShot.GetComponent<Shot>().damage += damageUp;
        }

		//Quaternion initialRotation = shotSpawn.localRotation;

		/*for (int i = 1 ; i <= nbShots; i++) 
		{

			if(i % 2 == 0)
			{
				shotSpawn.Rotate(new Vector3(0,0, i*interval));
			}
			else
			{
				shotSpawn.Rotate(new Vector3(0,0, -1*i*interval));
			}

			GameObject tempShot = Instantiate(shot, shotSpawn.position, shotSpawn.rotation) as GameObject;
			tempShot.GetComponent<Mover>().direction = shotSpawn.right;
			tempShot.GetComponent<Mover>().speed = speed;

		
		}

		shotSpawn.localRotation = initialRotation;*/
	}

	public static void ShootRandomCircle(Transform shotSpawn, GameObject shot, Vector2 direction, int nbShots, float inaccuracy ,float speed, float scale, int damageUp)
	{
		
		for (int i = 0; i < nbShots; i++) 
		{
			
			Vector2 Sdirection = UnityEngine.Random.insideUnitCircle * inaccuracy; 
			Sdirection.Normalize();

			float angle = Mathf.Atan2 (Sdirection.y, Sdirection.x) * Mathf.Rad2Deg + 180 ;
			Quaternion q = Quaternion.AngleAxis (angle, Vector3.forward);
			
			
			GameObject tempShot = Instantiate (shot, shotSpawn.position, q) as GameObject;
			tempShot.transform.localScale *= scale;
			tempShot.GetComponent<Mover> ().direction = Sdirection;
			tempShot.GetComponent<Mover> ().speed = speed;
            tempShot.GetComponent<Shot>().damage += damageUp;
        }
		
		
		
	}

	public static void ShootCircle(Transform shotSpawn, GameObject shot, int nbShot, float angle, float speed, float scale, int damageUp)
	{


		for (int i = 0; i< nbShot; i++) {
			
			float value = (float)i / (float)nbShot;
			//Debug.Log(value);
			float teta = (Mathf.PI * 2) * value + shotSpawn.localRotation.z;
			double phi = -Math.PI / 2;
			
			
			float pX = shotSpawn.position.x + (float)(Math.Sin (phi) * Math.Cos (teta));
			float pY = shotSpawn.position.y + (float)(Math.Sin (phi) * Math.Sin ((teta)));

			Vector2 firePoint = new Vector2 (pX, pY);

			
			Vector2 fireDirection = new Vector2 (firePoint.x - shotSpawn.position.x, firePoint.y - shotSpawn.position.y);
			fireDirection.Normalize ();

			
			
			
			GameObject tempShot = Instantiate (shot, shotSpawn.position, shotSpawn.rotation) as GameObject;
			tempShot.transform.localScale *= scale;
			tempShot.GetComponent<Mover> ().direction = fireDirection;
			tempShot.GetComponent<Mover> ().speed = speed;
            tempShot.GetComponent<Shot>().damage += damageUp;
        }
	}

	/*public static void ShootLaser(GameObject shooter, Transform shotSpawn, GameObject Laser, float timeLoad, float timeLaser, Vector3 direction, float scale)
	{
		GameObject newLaser = Instantiate (Laser, shotSpawn.position, Quaternion.identity) as GameObject;


		Laser laserScript = newLaser.GetComponent<Laser> ();
		if(laserScript != null)
		{	
			laserScript.shooter = shooter;
			laserScript.scale = scale;
			laserScript.position = shotSpawn.position ;//+ direction*3;
			laserScript.direction = direction;
			laserScript.loadTime = timeLoad;
			laserScript.laserTime = timeLaser;
		}
	}*/

}
