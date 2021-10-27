using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIDetectState : AIBaseState
{
    public override void EnterState(AIStateManager AI, Animator anim, NavMeshAgent agent)
    {

    }

    public override void UpdateState(AIStateManager AI, Animator anim, Transform[] way)
    {
        Debug.Log("Wesh");
    }
}
