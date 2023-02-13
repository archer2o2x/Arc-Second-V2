using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleListener : MonoBehaviour
{
    public BaseSystem ListeningSystem;

    public string PositiveTag;
    public string NegativeTag;

    public void Toggle()
    {
        if (ListeningSystem.SystemHasTag(NegativeTag)) ListeningSystem.SystemAddTag(PositiveTag);
        else ListeningSystem.SystemAddTag(NegativeTag);
    }
}
