using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAttackState : AIBaseState
{
    public override void EnterState(AIStateManager AI, Animator anim)
    {
        anim.SetBool("isPatrolling", false);
        anim.SetBool("isFollowing", false);
        anim.SetBool("isAttacking", true);

        AI.agent.isStopped = true;
    }

    public override void UpdateState(AIStateManager AI, Animator anim, Transform[] way)
    {

        if (Vector3.Distance(AI.agent.transform.position, AI.player.transform.position) > AI.ed.attackDistance)
        {
            AI.agent.isStopped = false;
            AI.SwitchState(AI.followState);
        }
    }
}
