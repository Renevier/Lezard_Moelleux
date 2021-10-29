using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatroleState : AIBaseState
{
    int goTo;

    public override void EnterState(AIStateManager AI, Animator anim)
    {
        if (AI.type == AIStateManager.TYPE.STATIC)
        {
            anim.SetBool("isPatrolling", false);
            AI.agent.isStopped = true;
        }
        else
        {
            anim.SetBool("isPatrolling", true);
            AI.agent.isStopped = false;
        }

        anim.SetBool("isFollowing", false);
        anim.SetBool("isAttacking", false);

        goTo = 0;
    }

    public override void UpdateState(AIStateManager AI, Animator anim, Transform[] way)
    {
        if (HasDetected(AI))
            AI.SwitchState(AI.followState);

        if (AI.type == AIStateManager.TYPE.FULL_PATROL)
        {
            if (Vector3.Distance(AI.agent.transform.position, way[goTo].position) <= .4f)
            {
                if (goTo < way.Length - 1)
                    goTo++;
                else
                    goTo = 0;
            }

            AI.agent.SetDestination(way[goTo].position);
        }
        else if (AI.type == AIStateManager.TYPE.STATIC)
        {
            AI.transform.eulerAngles = new Vector3(0, AI.transform.eulerAngles.y + .2f, 0);
        }
    }

}
