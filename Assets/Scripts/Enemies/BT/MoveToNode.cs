using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AlanZucconi.AI.BT;
using UnityEngine.AI;

public class MoveToNode : Leaf
{
    private NavMeshAgent EnemyAgent;
    private Transform EnemyTarget;

    public MoveToNode(NavMeshAgent agent, Transform target)
    {
        EnemyAgent = agent;
        EnemyTarget = target;
    }

    public override Status Evaluate()
    {
        if (EnemyAgent.destination != EnemyTarget.position) EnemyAgent.destination = EnemyTarget.position;

        if (EnemyAgent.remainingDistance <= 0) return Status.Success;

        if (EnemyAgent.path.status == NavMeshPathStatus.PathInvalid && !EnemyAgent.pathPending) return Status.Failure;

        return Status.Running;
    }
}
