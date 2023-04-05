using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Vector2 rawInput;
    Vector2 minScreenBoundary;
    Vector2 maxScreenBoundary;

    private void Start() {
        InitBoundaries();
    }

    void InitBoundaries() {
        Camera cam = Camera.main;
        minScreenBoundary = cam.ViewportToWorldPoint(new Vector2(0, 0));
        maxScreenBoundary = cam.ViewportToWorldPoint(new Vector2(1, 1));
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 delta = rawInput * K.Player.MoveSpeed * Time.deltaTime;

        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minScreenBoundary.x + K.Screen.Padding.Left, maxScreenBoundary.x - K.Screen.Padding.Right);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minScreenBoundary.y + K.Screen.Padding.Bottom, maxScreenBoundary.y - K.Screen.Padding.Top);

        transform.position = newPos;
    }

    void OnMove(InputValue value) {
        rawInput = value.Get<Vector2>();
    }

}
