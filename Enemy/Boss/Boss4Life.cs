using UnityEngine;
using System.Collections;

public class Boss4Life : AgentLife
{
    protected override void Death()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.GetComponent<Free2DMovement>().speed *= 2;
            player.GetComponent<Free2DMovement>().speedBoost = true;
        }

        EndScript.NbBossKilled++;

        base.Death();
    }
}
