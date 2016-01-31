using UnityEngine;
using System.Collections;

public class KingKamikazeController : MonoBehaviour {

    public FireCone pattern;
    public float kamikazeSpeed;
    public int nbKamikazeToInstantiate;

    AgentLife life;

	// Use this for initialization
	void Start ()
    {
        life = GetComponent<AgentLife>();
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (life.currentLife / life.startingLife < 0.5f)
        {
           // pattern.nbShot[0] = 6;


        }
	
	}
}
