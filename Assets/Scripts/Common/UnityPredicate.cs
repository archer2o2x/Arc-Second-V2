using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UnityPredicate : UnityEngine.Object
{
    public enum AdditionMode
    {
        ALL,
        ANY,
        NONE
    }

    public List<Func<bool>> PredicateFunctions;

    public AdditionMode PredicateMode;

    public void TryCreate()
    {
        if (PredicateFunctions != null) return;
        PredicateFunctions = new List<Func<bool>>();
    }

    public void AddListener(Func<bool> listener)
    {
        TryCreate();
        PredicateFunctions.Add(listener);
    }

    public void RemoveListener(Func<bool> listener)
    {
        TryCreate();
        PredicateFunctions.Remove(listener);
    }

    public bool Invoke()
    {
        return Invoke(PredicateMode);
    }

    public bool Invoke(AdditionMode additionMode)
    {
        TryCreate();
        int trueResults = 0;

        for (int i = 0; i < PredicateFunctions.Count; i++)
        {
            trueResults += PredicateFunctions[i].Invoke() ? 1 : 0;
        }

        switch (additionMode)
        {
            case AdditionMode.ALL: return trueResults == PredicateFunctions.Count;
            case AdditionMode.ANY: return trueResults > 0;
            case AdditionMode.NONE: return trueResults == 0;
            default: return false;
        }
    }

    public int GetCount()
    {
        TryCreate();
        return PredicateFunctions == null ? 0 : PredicateFunctions.Count;
    }
}
