using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    public static UnityEvent<Vector2> OnMove = new UnityEvent<Vector2>();
    
    public static bool IsCanChangeGravity;
    public static bool IsCanActiveShovel;
    private static bool m_IsLocked;
    private static bool m_IsMoveLocked;
    private static Vector2 m_MoveDir;

    private void Update()
    {
        m_MoveDir = Vector2.zero;

        if (!m_IsLocked)
        {
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
                if (IsCanChangeGravity)
                {
                    Debug.Log("Change Gravity");
                    Gravity.TurnLeft();
                    IsCanChangeGravity = false;
                    m_IsMoveLocked = false;
                }
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (IsCanChangeGravity)
                {
                    Debug.Log("Change Gravity");
                    Gravity.TurnRight();
                    IsCanChangeGravity = false;
                    m_IsMoveLocked = false;
                }
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                if (IsCanActiveShovel)
                {
                    IsCanActiveShovel = false;
                    Hero.OnActiveShovel.Invoke();
                    Lock();
                }
            }
        }

        if (!m_IsMoveLocked) OnMove?.Invoke(m_MoveDir);
    }

    public static void Init()
    {
        IsCanChangeGravity = true;
        IsCanActiveShovel = true;

        Unlock();
        UnlockMove();
    }

    public static void Lock()
    {
        m_IsLocked = true;
    }

    public static void LockMove()
    {
        m_IsMoveLocked = true;
    }

    public static void Unlock()
    {
        m_IsLocked = false;
    }

    public static void UnlockMove()
    {
        m_IsMoveLocked = false;
    }
}
