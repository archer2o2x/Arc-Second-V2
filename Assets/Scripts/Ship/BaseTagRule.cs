using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable()]
public class BaseTagRule
{
    public string TriggerTag;
    public string TargetTag;
    public TriggerState TriggerTagEvent;
    public TargetEffect TargetEffectOperations;

    public enum TriggerState
    {
        OnCreation,
        OnDestruction
    }

    public enum TargetEffect
    {
        AddTrigger,
        AddTarget,
        RemoveTrigger,
        RemoveTarget,
        IfTargetAddTrigger,
        IfTargetRemoveTrigger
    }
}
