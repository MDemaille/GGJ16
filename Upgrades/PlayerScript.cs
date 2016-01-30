using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    //private enum LifeUpgrades { NONE, LIFE1, LIFE2, LIFE3 };
    //private enum SpeedUpgrades { NONE, SPE1, SPE2, SPE3 };
    //private enum DamageUpgrades { NONE, DMG1, DMG2, DMG3 };

    private int lifeUp;
    private int speUp;
    private int dmgUp;
    private int rateUp;

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
        get { return dmgUp; }
        set { dmgUp = value; }
    }

    public int SpeUp {
        get { return dmgUp; }
        set { dmgUp = value; }
    }

    public int DmgUp {
        get { return dmgUp; }
        set { dmgUp = value; }
    }

    public int RateUp {
        get { return dmgUp; }
        set { dmgUp = value; }
    }
}
