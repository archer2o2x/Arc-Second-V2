using AlanZucconi.AI.BT;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent EnemyAgent;
    public Transform EnemyTarget;

    public Transform EnemyEyes;

    public Node behaviour;

    void Start()
    {
        behaviour =
            new Selector(
                new Sequence(
                    new CanSeePlayer(EnemyEyes, EnemyTarget),
                    new AlignToNode(EnemyTarget, EnemyEyes, 0.1f),
                    new MoveToNode(EnemyAgent, EnemyTarget)
                )
            );
    }

    // Update is called once per frame
    void Update()
    {
        behaviour.Evaluate();
    }
}
