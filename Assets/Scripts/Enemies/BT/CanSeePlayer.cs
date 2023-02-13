using AlanZucconi.AI.BT;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanSeePlayer : Leaf
{
    private float DetectionDistance = 25;
    private float AngleOfView = 75;

    private Transform Player;
    private Transform Enemy;

    public CanSeePlayer(Transform EnemyTransform, Transform PlayerTransform)
    {
        Player = PlayerTransform;
        Enemy = EnemyTransform;
    }

    public override Status Evaluate()
    {
        if (Vector3.Distance(Enemy.position, Player.position) > DetectionDistance) return Status.Failure;

        if (Vector3.Angle(Enemy.forward, (Player.position - Enemy.position).normalized) > AngleOfView) return Status.Failure;

        RaycastHit info;

        if (Physics.Raycast(Enemy.position, (Player.position - Enemy.position).normalized, out info, DetectionDistance))
        {
            if (info.collider.gameObject.tag == "Player") return Status.Success;
        }

        return Status.Failure;
    }
}
