using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    public static UnityEvent<Vector2> OnMove = new UnityEvent<Vector2>();

    private static Vector2 m_MoveDir;

    private void Update()
    {
        m_MoveDir = Vector2.zero;

        if (Input.GetKey(KeyCode.A))
        {
            if (GravityDirection.GravityDir == GravityDir.Up || GravityDirection.GravityDir == GravityDir.Down)
            {
                m_MoveDir = new Vector2(-1, 0);
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (GravityDirection.GravityDir == GravityDir.Up || GravityDirection.GravityDir == GravityDir.Down)
            {
                m_MoveDir = new Vector2(1, 0);
            }
        }

        if (Input.GetKey(KeyCode.W))
        {
            if (GravityDirection.GravityDir == GravityDir.Left || GravityDirection.GravityDir == GravityDir.Right)
            {
                m_MoveDir = new Vector2(0, 1);
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (GravityDirection.GravityDir == GravityDir.Left || GravityDirection.GravityDir == GravityDir.Right)
            {
                m_MoveDir = new Vector2(0, -1);
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            GravityDirection.TurnLeft();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            GravityDirection.TurnRight();
        }

        OnMove?.Invoke(m_MoveDir);
    }
}
