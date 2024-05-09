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
            if (Gravity.GravityDir == GravityDirection.Up || Gravity.GravityDir == GravityDirection.Down)
            {
                m_MoveDir = new Vector2(-1, 0);
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (Gravity.GravityDir == GravityDirection.Up || Gravity.GravityDir == GravityDirection.Down)
            {
                m_MoveDir = new Vector2(1, 0);
            }
        }

        if (Input.GetKey(KeyCode.W))
        {
            if (Gravity.GravityDir == GravityDirection.Left || Gravity.GravityDir == GravityDirection.Right)
            {
                m_MoveDir = new Vector2(0, 1);
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (Gravity.GravityDir == GravityDirection.Left || Gravity.GravityDir == GravityDirection.Right)
            {
                m_MoveDir = new Vector2(0, -1);
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Gravity.TurnLeft();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Gravity.TurnRight();
        }

        OnMove?.Invoke(m_MoveDir);
    }
}
