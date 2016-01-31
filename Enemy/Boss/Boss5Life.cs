using UnityEngine;
using System.Collections;

public class Boss5Life : AgentLife
{
    protected override void Death()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.GetComponent<PlayerAttack>().missilePoussinBoost = true;
            player.GetComponent<PlayerAttack>().UIPoussin.GetComponent<SecondaryWeapon>().enabled = true;
        }

        EndScript.NbBossKilled++;

        base.Death();
    }
}
