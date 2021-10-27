using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIPatroleState : AIBaseState
{
    private NavMeshAgent agent;

    int goTo;

    public override void EnterState(AIStateManager AI, Animator anim, NavMeshAgent _agent)
    {
        goTo = 0;
        agent = _agent;
    }

    public override void UpdateState(AIStateManager AI, Animator anim, Transform[] way)
    {
        anim.SetBool("isPatrolling", true);

        if (AI.type == AIStateManager.TYPE.FULL_PATROL)
        {
            if (Vector3.Distance(agent.transform.position, way[goTo].position) <= .4f)
            {
                if (goTo < way.Length - 1)
                    goTo++;
                else
                    goTo = 0;
            }

            agent.SetDestination(way[goTo].position);
        }

        if (Vector3.Distance(agent.transform.position, AI.player.transform.position) <= AI.ed.detectionDistance)
            AI.SwitchState(AI.detectState);

    }

}
