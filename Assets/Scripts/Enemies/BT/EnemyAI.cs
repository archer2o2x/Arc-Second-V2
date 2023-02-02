using AlanZucconi.AI.BT;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform target;

    public Node behaviour;

    void Start()
    {
        behaviour = new Selector(
            new MoveToNode(agent, target)
        );
    }

    // Update is called once per frame
    void Update()
    {
        behaviour.Evaluate();
    }
}
