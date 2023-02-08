using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrusterSystem : BaseSystem
{
    public override void ProcessNegativeTags()
    {
        foreach (string tag in _NegativeTags)
        {
            switch (tag)
            {
                case "misaligned": break;
            }
        }
    }
}
