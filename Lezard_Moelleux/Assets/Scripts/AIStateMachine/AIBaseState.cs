using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class AIBaseState
{
    public abstract void EnterState(AIStateManager AI, Animator anim);

    public abstract void UpdateState(AIStateManager AI, Animator anim, Transform[] way);

    public bool HasDetected(AIStateManager AI)
    {
        bool hasDetected = false;

        if (Vector3.Dot(AI.transform.forward, AI.player.transform.position - AI.transform.position) > 0 &&
            Vector3.Distance(AI.agent.transform.position, AI.player.transform.position) <= (hasDetected ? AI.ed.detectionDistance : AI.ed.detectionDistance * 2))
            hasDetected = true;

        return hasDetected;
    }
}
