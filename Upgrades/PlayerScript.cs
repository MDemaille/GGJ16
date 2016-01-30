using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    //private enum LifeUpgrades { NONE, LIFE1, LIFE2, LIFE3 };
    //private enum SpeedUpgrades { NONE, SPE1, SPE2, SPE3 };
    //private enum DamageUpgrades { NONE, DMG1, DMG2, DMG3 };

    public int lifeUp;
    public int speUp;
    public int dmgUp;
    public int rateUp;

    //private Animator animator;

	// Use this for initialization
	void Start () {
        lifeUp = 0;
        speUp = 0;
        dmgUp = 0;
        rateUp = 0;
        //animator = GetComponent<Animator>();
    }

    public int LifeUp {
        get { return lifeUp; }
        set { lifeUp = value; }
    }

    public int SpeUp {
        get { return speUp; }
        set { speUp = value; }
    }

    public int DmgUp {
        get { return dmgUp; }
        set { dmgUp = value; }
    }

    public int RateUp {
        get { return rateUp; }
        set { rateUp = value; }
    }
}
