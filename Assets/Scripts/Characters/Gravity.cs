using UnityEngine;
using UnityEngine.Events;

public enum GravityDir
{
    Up,
    Down,
    Left,
    Right
}

public static class Gravity
{
    public static UnityEvent<Vector2> OnGravityChanged = new UnityEvent<Vector2>();
    public static UnityEvent OnGravityChangeEnd = new UnityEvent();

    public static Vector2 VectorDir;
    public static GravityDir GravityDir;

    private static Vector2 NewDir;

    private static float m_TurnSpeed = 2f;

    private static float m_X;
    private static float m_Y;

    private static bool m_IsGravityChange = false;

    public static void Start()
    {
        VectorDir = new Vector2(0, -1);
        GravityDir = GravityDir.Down;
    }

    public static void Up()
    {
        GravityDir = GravityDir.Up;
        NewDir = new Vector2(0, 1);
        ChangeGravity();
    }

    public static void Down()
    {
        GravityDir = GravityDir.Down;
        NewDir = new Vector2(0, -1);
        ChangeGravity();
    }

    public static void Left()
    {
        GravityDir = GravityDir.Left;
        NewDir = new Vector2(-1, 0);
        ChangeGravity();
    }

    public static void Right()
    {
        GravityDir = GravityDir.Right;
        NewDir = new Vector2(1, 0);
        ChangeGravity();
    }

    public static void TurnLeft()
    {
        switch(GravityDir)
        {
            case GravityDir.Up:    Left(); break;
            case GravityDir.Down:  Right(); break;
            case GravityDir.Left:  Down(); break;
            case GravityDir.Right: Up(); break;
        }
    }

    public static void TurnRight()
    {
        switch (GravityDir)
        {
            case GravityDir.Up:    Right(); break;
            case GravityDir.Down:  Left(); break;
            case GravityDir.Left:  Up(); break;
            case GravityDir.Right: Down(); break;
        }
    }

    private static void ChangeGravity()
    {
        m_IsGravityChange = true;

        m_X = VectorDir.x;
        m_Y = VectorDir.y;

        OnGravityChanged?.Invoke(VectorDir);
    }

    private static void GravityChangeEnd()
    {
        m_IsGravityChange = false;

        OnGravityChangeEnd?.Invoke();
    }

    private static void TurnGravity()
    {
        if (NewDir.x > m_X)
        {
            m_X += m_TurnSpeed * Time.deltaTime;
        }
        else if (NewDir.x < m_X)
        {
            m_X -= m_TurnSpeed * Time.deltaTime;
        }

        if (NewDir.y > m_Y)
        {
            m_Y += m_TurnSpeed * Time.deltaTime;
        }
        else if (NewDir.y < m_Y)
        {
            m_Y -= m_TurnSpeed * Time.deltaTime;
        }

        if ((NewDir - new Vector2(m_X, m_Y)).magnitude < 0.1f)
        {
            VectorDir = NewDir;
            GravityChangeEnd();
        }
        else VectorDir = new Vector2(m_X, m_Y);
    }

    public static void Update()
    {
        if (m_IsGravityChange)
        {
            TurnGravity();
        }
    }
}


