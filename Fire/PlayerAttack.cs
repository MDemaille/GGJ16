using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{

    public enum Weapon
    {
        BASICEGG,
        GOLDENEGG
    }


    public bool goldenEggBoost = false;
    public bool coneBoost = false;
    public bool missilePoussinBoost = false;


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

            if (goldenEggBoost)
            {
                Fire.ShootDirection(shotSpawn, goldenEgg, toPointCursor, shotSpeed, shotScale, damageUp);
                if (coneBoost)
                    Fire.ShootCone(shotSpawn, goldenEgg, toPointCursor, 2, shotSpeed, 70, 1.0f, damageUp);

            }
            else
            {
                Fire.ShootDirection(shotSpawn, basicEgg, toPointCursor, shotSpeed, shotScale, damageUp);
                if (coneBoost)
                    Fire.ShootCone(shotSpawn, basicEgg, toPointCursor, 2, shotSpeed, 70, 1.0f, damageUp);
            }

        }

        if (Input.GetButton("Fire2") && SecondaryWeapon.secondaryWeaponReady && missilePoussinBoost)
        {
            Fire.ShootDirection(shotSpawn, missilePoussin, toPointCursor, shotSpeed, 1f, 0);
            SecondaryWeapon.Reset();
        }

    }
}

