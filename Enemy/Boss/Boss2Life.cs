using UnityEngine;
using System.Collections;

public class Boss2Life : AgentLife
{
    protected override void Death()
    {

        SlimmingPouleController controller = GetComponent<SlimmingPouleController>();

       

        if (controller.currentDivision < controller.numberOfDivision)
        {
            controller.divide();
        }

        gameObject.transform.parent.gameObject.GetComponent<SlimBossCount>().nbBoss--;
        base.Death();
    }
}
