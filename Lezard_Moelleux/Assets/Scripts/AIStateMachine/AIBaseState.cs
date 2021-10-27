using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class AIBaseState
{
    public abstract void EnterState(AIStateManager AI, Animator anim, NavMeshAgent agent);

    public abstract void UpdateState(AIStateManager AI, Animator anim, Transform[] way);

    public bool HasDetected()
    {
        return false;
    }
}
