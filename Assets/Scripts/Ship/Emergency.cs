using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Emergency", menuName = "Ship/Emergency")]
public class Emergency : ScriptableObject
{
    public string EmergencyName;
    [TextArea]
    public string EmergencyDescription;

    public Problem[] EmergencyProblems;
}

[System.Serializable]
public class Problem
{
    public string ProblemSystem;
    public string ProblemEffectTag;
    public string ProblemFixedTag;
}
