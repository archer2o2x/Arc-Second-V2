using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BaseSystem : MonoBehaviour
{
    [HideInInspector]
    public List<string> SystemTags { get => _SystemTags; }

    [SerializeField]
    protected List<string> _SystemTags;
    [SerializeField]
    public BaseTagRule[] TagRules;

    public UnityEvent OnTagCreate;
    public UnityEvent OnTagDestruction;



    private void OnCreate(string newtag)
    {
        foreach (BaseTagRule rule in TagRules)
        {
            if (rule.TriggerTagEvent != BaseTagRule.TriggerState.OnCreation) continue;

            if (rule.TriggerTag != newtag) continue;

            switch (rule.TargetEffectOperations)
            {
                case BaseTagRule.TargetEffect.AddTrigger: AddTag(rule.TriggerTag); break;
                case BaseTagRule.TargetEffect.AddTarget: AddTag(rule.TargetTag); break;
                case BaseTagRule.TargetEffect.RemoveTrigger: RemoveTag(rule.TriggerTag); break;
                case BaseTagRule.TargetEffect.RemoveTarget: RemoveTag(rule.TargetTag); break;
                case BaseTagRule.TargetEffect.IfTargetAddTrigger: if (HasTag(rule.TargetTag)) AddTag(rule.TriggerTag); break;
                case BaseTagRule.TargetEffect.IfTargetRemoveTrigger: if (!HasTag(rule.TargetTag)) AddTag(rule.TriggerTag); break;
            }
        }

        OnTagCreate.Invoke();
    }

    private void OnDestruction(string newtag)
    {
        foreach (BaseTagRule rule in TagRules)
        {
            if (rule.TriggerTagEvent != BaseTagRule.TriggerState.OnDestruction) continue;

            if (rule.TriggerTag != newtag) continue;

            switch (rule.TargetEffectOperations)
            {
                case BaseTagRule.TargetEffect.AddTrigger: AddTag(rule.TriggerTag); break;
                case BaseTagRule.TargetEffect.AddTarget: AddTag(rule.TargetTag); break;
                case BaseTagRule.TargetEffect.RemoveTrigger: RemoveTag(rule.TriggerTag); break;
                case BaseTagRule.TargetEffect.RemoveTarget: RemoveTag(rule.TargetTag); break;
                case BaseTagRule.TargetEffect.IfTargetAddTrigger: if (!HasTag(rule.TargetTag)) RemoveTag(rule.TriggerTag); break;
                case BaseTagRule.TargetEffect.IfTargetRemoveTrigger: if (HasTag(rule.TargetTag)) RemoveTag(rule.TriggerTag); break;
            }
        }

        OnTagDestruction.Invoke();
    }


    #region HELPER FUNCS
    private bool HasTag(string tag)
    {
        return _SystemTags.Contains(tag);
    }

    private void AddTag(string tag)
    {
        if (!HasTag(tag)) _SystemTags.Add(tag);
    }

    private void RemoveTag(string tag)
    {
        _SystemTags.Remove(tag);
    }

    public bool SystemHasTag(string tag)
    {
        return _SystemTags.Contains(tag);
    }

    public void SystemAddTag(string tag)
    {
        OnCreate(tag);
    }

    public void SystemRemoveTag(string tag)
    {
        OnDestruction(tag);
    }

    #endregion
}
