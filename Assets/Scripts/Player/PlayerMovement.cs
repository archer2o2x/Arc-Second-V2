using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    private CharacterController character;

    private Transform PlayerBody;
    public Transform PlayerHead;

    public float CharacterSpeed;
    public float PlayerLookSpeed;
    public float PlayerJumpForce;

    private Vector2 PlayerMoveVector;
    private Vector2 PlayerLookVector;

    public float MaxGravity;

    private float PlayerVerticalAcceleration;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();

        PlayerBody = transform;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        PlayerVerticalAcceleration = -MaxGravity;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 motion = PlayerMoveVector * Time.deltaTime;

        character.Move(PlayerBody.localToWorldMatrix * new Vector3(motion.x, PlayerVerticalAcceleration, motion.y));

        Vector2 rotation = PlayerLookVector * Time.deltaTime;

        PlayerBody.RotateAround(PlayerBody.position, PlayerBody.up, rotation.x);
        PlayerHead.RotateAround(PlayerHead.position, PlayerHead.right, -rotation.y);

        if (PlayerVerticalAcceleration == -MaxGravity) return;

        PlayerVerticalAcceleration -= MaxGravity * Time.deltaTime;

        if (PlayerVerticalAcceleration < -MaxGravity) PlayerVerticalAcceleration = -MaxGravity;
    }

    public void OnMove(InputValue context)
    {
        PlayerMoveVector = context.Get<Vector2>().normalized * CharacterSpeed;
    }

    public void OnLook(InputValue context)
    {
        PlayerLookVector = context.Get<Vector2>() * PlayerLookSpeed;
    }

    public void OnJump()
    {
        PlayerVerticalAcceleration = PlayerJumpForce;
    }
}
