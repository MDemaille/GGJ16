using UnityEngine;
using System.Collections;

public class SlimBossCount : MonoBehaviour {

    public int nbBoss = 1;
	// Update is called once per frame
	void Update ()
    {
        if (nbBoss == 0)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                player.GetComponent<PlayerAttack>().coneBoost = true;
                GetComponent<BossFocus>().Unfocus();
            }

            EndScript.NbBossKilled++;

            enabled = false;
        }
    }
}
