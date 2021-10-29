using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIIdleState : AIBaseState
{
    public override void EnterState(AIStateManager AI, Animator anim)
    {
        anim.SetBool("isPatrolling", false);
        anim.SetBool("isFollowing", false);
        anim.SetBool("isAttacking", false);
    }

    public override void UpdateState(AIStateManager AI, Animator anim, Transform[] way)
    {
        if (HasDetected(AI))
            AI.SwitchState(AI.followState);
        else
            AI.SwitchState(AI.patroleState);

    }
}
