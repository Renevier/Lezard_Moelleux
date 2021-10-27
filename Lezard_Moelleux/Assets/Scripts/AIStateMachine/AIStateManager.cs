using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIStateManager : MonoBehaviour
{
    public enum TYPE
    {
        HALF_PATROL,
        FULL_PATROL,
        RANDOM_PATROL
    }

    [SerializeField] public TYPE type;
    [SerializeField] private Transform[] way;
    [SerializeField] private Animator anim;
    public EnemyData ed;
    public PlayerController player;

    private AIBaseState currentState;

    public AIIdleState idleState = new AIIdleState();
    public AIPatroleState patroleState = new AIPatroleState();
    public AIFollowState followState = new AIFollowState();
    public AIAttackState attackState = new AIAttackState();
    public AIDetectState detectState = new AIDetectState();

    [SerializeField] protected NavMeshAgent agent = null;

    private void Start()
    {
        currentState = idleState;

        currentState.EnterState(this, anim, agent);
    }

    private void Update()
    {
        currentState.UpdateState(this, anim, way);
    }

    public void SwitchState(AIBaseState state)
    {
        currentState = state;

        state.EnterState(this, anim, agent);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, ed.detectionDistance);
    }
}
