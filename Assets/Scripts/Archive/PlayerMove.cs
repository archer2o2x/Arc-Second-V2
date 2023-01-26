using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
    private Rigidbody PlayerRB;
    public float PlayerWalkSpeed;
    public float PlayerSprintMultiplier;
    public float PlayerJumpForce;

    private Vector2 MoveInput;

    // Start is called before the first frame update
    void Start()
    {
        PlayerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 NewPosition = transform.position;
        Vector2 direction = MoveInput * PlayerSprintMultiplier * Time.deltaTime;

        PlayerRB.MovePosition(NewPosition + Vector3.right * direction.x + Vector3.forward * direction.y);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MoveInput = context.ReadValue<Vector2>().normalized * PlayerWalkSpeed;
    }
}
