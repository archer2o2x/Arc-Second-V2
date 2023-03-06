using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmergencyManager : MonoBehaviour
{
    public ScheduledEmergency[] ScheduledEmergencies;

    public float TripStartTime;

    public float TripEndTIme;

    private void Update()
    {
        foreach (ScheduledEmergency emergency in ScheduledEmergencies)
        {
            
        }
    }
}

[System.Serializable]
public class ScheduledEmergency
{
    public Emergency ActivatedEmergency;
    public float TimeIntoTrip;
    [HideInInspector]
    public bool Triggered = false;
}
