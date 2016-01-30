using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{

    public enum Weapon
    {
        BASICEGG,
        GOLDENEGG
    }

    public GameObject goldenEgg;
    public GameObject basicEgg;

	public GameObject missilePoussin;

    public Transform shotSpawn;

    public float shotSpeed;
    public float shotScale;

    public float fireRate = 0.2f;

    private float nextFire;

    public int damageUp = 0;

    public Weapon weapon = Weapon.BASICEGG;

    public int goldenEggFrequency;
    private int nextGoldenEgg;

    // Use this for initialization
    void Start()
    {
        nextGoldenEgg = goldenEggFrequency;
    }

    // Update is called once per frame
    void Update()
    {
        
		Vector3 toPointCursor = Camera.main.ScreenToWorldPoint(Input.mousePosition) - shotSpawn.position;
       
		if (Input.GetButton("Fire1") && Time.time > nextFire)
       {
            nextFire = Time.time + fireRate;
			switch (weapon) {
			case (Weapon.BASICEGG):
				Fire.ShootDirection (shotSpawn, basicEgg, toPointCursor, shotSpeed, shotScale, damageUp);
				break;
			case (Weapon.GOLDENEGG):
				Fire.ShootCone (shotSpawn, basicEgg, toPointCursor, 2, shotSpeed, 70, 1.0f, damageUp);
				if (nextGoldenEgg <= 0) {
					Fire.ShootDirection (shotSpawn, goldenEgg, toPointCursor, shotSpeed, shotScale, damageUp);
					nextGoldenEgg = goldenEggFrequency;
				} else
					nextGoldenEgg--;

				break;

			}

		}else if(Input.GetButton("Fire2") && SecondaryWeapon.secondaryWeaponReady){
			Fire.ShootDirection (shotSpawn, missilePoussin, toPointCursor, shotSpeed, 1f, 0);
			SecondaryWeapon.Reset ();
		}

           
            
            //Fire.ShootCone(shotSpawn, shotToFire, toPointCursor, 4, shotSpeed * 1.1f, 60, 0.9f);
           // Fire.ShootRandomCircle(shotSpawn, shotToFire, toPointCursor, 10, 1.0f, shotSpeed, 1.0f);
            //Fire.ShootCircle(shotSpawn, shotToFire, 10, 0, shotSpeed, 1.0f);
    }
}
