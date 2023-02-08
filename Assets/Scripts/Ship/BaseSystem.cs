using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSystem : MonoBehaviour
{
    public List<string> SystemNegativeTags { get => _NegativeTags; }
    public List<string> SystemPositiveTags { get => _PositiveTags; }

    protected List<string> _NegativeTags;
    protected List<string> _PositiveTags;

    public abstract void ProcessNegativeTags();

    #region HELPER FUNCS
    public bool HasNegativeTag(string tag)
    {
        return _NegativeTags.Contains(tag);
    }
    public bool HasPositiveTag(string tag)
    {
        return _PositiveTags.Contains(tag);
    }

    public void AddNegativeTag(string tag)
    {
        _NegativeTags.Add(tag);
    }

    public void AddPositiveTag(string tag)
    {
        _PositiveTags.Add(tag);
    }

    public void RemoveNegativeTag(string tag)
    {
        _NegativeTags.Remove(tag);
    }

    public void RemovePositiveTag(string tag)
    {
        _PositiveTags.Remove(tag);
    }

    #endregion
}
