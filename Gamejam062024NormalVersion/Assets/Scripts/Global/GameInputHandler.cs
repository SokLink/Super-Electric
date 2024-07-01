using System;
using UnityEngine;

public class GameInputHandler : MonoBehaviour
{
    public static event Action OnJumpPressed;
    public static event Action OnInteractPressed;

    public static Vector2 MoveDirection { get; private set; }

    void Update()
    {
        MoveDirection = Vector2.zero;

        if (Input.GetKey(KeyCode.A)) MoveDirection += Vector2.left;
        if (Input.GetKey(KeyCode.D)) MoveDirection += Vector2.right;

        if (Input.GetKey(KeyCode.W)) MoveDirection += Vector2.up;
        if (Input.GetKey(KeyCode.S)) MoveDirection += Vector2.down;

        MoveDirection = MoveDirection.normalized;

        if (Input.GetKeyDown(KeyCode.Space)) OnJumpPressed?.Invoke();

        if (Input.GetKeyDown(KeyCode.F)) OnInteractPressed?.Invoke();
    }
}
