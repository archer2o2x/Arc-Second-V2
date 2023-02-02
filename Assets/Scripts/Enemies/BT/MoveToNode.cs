using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AlanZucconi.AI.BT;
using UnityEngine.AI;

public class MoveToNode : Leaf
{
    private NavMeshAgent EnemyAgent;
    private Vector3 EnemyTarget;

    public MoveToNode(NavMeshAgent agent, Vector3 target)
    {
        EnemyAgent = agent;
        EnemyTarget = target;
    }

    public override Status Evaluate()
    {
        if (EnemyAgent.destination != EnemyTarget) EnemyAgent.destination = EnemyTarget;

        if (EnemyAgent.remainingDistance <= 0) return Status.Success;

        if (EnemyAgent.path.status == NavMeshPathStatus.PathInvalid && !EnemyAgent.pathPending) return Status.Failure;

        return Status.Running;
    }
}
