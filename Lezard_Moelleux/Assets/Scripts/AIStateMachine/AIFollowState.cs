using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFollowState : AIBaseState
{
    public override void EnterState(AIStateManager AI, Animator anim)
    {
        anim.SetBool("isPatrolling", false);
        anim.SetBool("isFollowing", true);
        anim.SetBool("isAttacking", false);

        AI.agent.isStopped = false;
    }

    public override void UpdateState(AIStateManager AI, Animator anim, Transform[] way)
    {
        if (Vector3.Distance(AI.agent.transform.position, AI.player.transform.position) <= AI.ed.attackDistance)
            AI.SwitchState(AI.attackState);

        if (!HasDetected(AI))
            AI.SwitchState(AI.idleState);

        AI.agent.SetDestination(AI.player.transform.position);
    }
}
