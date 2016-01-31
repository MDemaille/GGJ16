using UnityEngine;
using System.Collections;

public class Boss3Life : AgentLife
{
    protected override void Death()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.GetComponent<PlayerAttack>().fireRate /=2;
        }

        EndScript.NbBossKilled++;

        transform.parent.gameObject.GetComponent<BossFocus>().Unfocus();

        base.Death();
    }
}
