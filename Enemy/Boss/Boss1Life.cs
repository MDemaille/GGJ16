using UnityEngine;
using System.Collections;

public class Boss1Life : AgentLife
{
    protected override void Death()
    {

        transform.parent.GetComponent<BossFocus>().Unfocus();

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.GetComponent<PlayerAttack>().goldenEggBoost = true;
        }
        EndScript.NbBossKilled++;
        base.Death();
    }
}
