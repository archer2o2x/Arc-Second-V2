using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorListener : MonoBehaviour
{
    public BaseSystem ListeningSystem;

    public string OpenDoorTag;

    public GameObject DoorObject;
    public Vector3 DoorOffset;
    public AnimationCurve DoorCurve;
    public float DoorTransitionTime;

    private Vector3 DoorStartingPosition;
    private float TransitionTimeLeft;

    private bool Open;

    private void Start()
    {
        TransitionTimeLeft = 0;
        DoorStartingPosition = DoorObject.transform.position;
        Open = false;

        ListeningSystem.OnTagCreate.AddListener(OnChangedTag);
        ListeningSystem.OnTagDestruction.AddListener(OnChangedTag);
    }

    void Update()
    {
        if (TransitionTimeLeft <= 0) return;

        TransitionTimeLeft -= Time.deltaTime;

        if (Open)
        {
            DoorObject.transform.position = Vector3.Lerp(DoorStartingPosition + DoorOffset, DoorStartingPosition, DoorCurve.Evaluate(TransitionTimeLeft / DoorTransitionTime));
        } 
        else
        {
            DoorObject.transform.position = Vector3.Lerp(DoorStartingPosition, DoorStartingPosition + DoorOffset, DoorCurve.Evaluate(TransitionTimeLeft / DoorTransitionTime));
        }
    }

    public void OnChangedTag()
    {
        bool PrevOpenState = Open;

        Open = ListeningSystem.SystemHasTag(OpenDoorTag);

        if (PrevOpenState != Open) TransitionTimeLeft = DoorTransitionTime - TransitionTimeLeft;
    }
}
