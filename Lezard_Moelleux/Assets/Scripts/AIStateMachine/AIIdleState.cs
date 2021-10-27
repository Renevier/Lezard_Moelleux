using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIIdleState : AIBaseState
{
    float timeToPatrol = 0;

    public override void EnterState(AIStateManager AI, Animator anim, NavMeshAgent agent)
    {
        anim.Play("IdleAnimation");
    }

    public override void UpdateState(AIStateManager AI, Animator anim, Transform[] way)
    {
        if (timeToPatrol < 2f && !HasDetected())
        {
            timeToPatrol += Time.deltaTime;
            anim.SetBool("isPatrolling", false);
        }
        else if (timeToPatrol >= 2f && !HasDetected())
        {
            AI.SwitchState(AI.patroleState);
        }
        else if (HasDetected())
        {
            //Switch state to detect state
        }
    }
}
