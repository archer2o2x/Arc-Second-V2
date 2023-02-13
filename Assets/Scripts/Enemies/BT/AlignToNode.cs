using AlanZucconi.AI.BT;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignToNode : Leaf
{
    private Transform Target;
    private Transform Eyes;
    private float Amount;

    public AlignToNode(Transform target, Transform eyes, float amount)
    {
        Target = target;
        Eyes = eyes;
        Amount = amount;
    }

    public override Status Evaluate()
    {
        Vector3 lookDirection = (Target.position - Eyes.position).normalized;

        Eyes.forward = Vector3.Lerp(Eyes.forward, lookDirection, Amount);

        return Status.Success;
    }
}
