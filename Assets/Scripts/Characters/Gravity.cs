using UnityEngine;
using UnityEngine.Events;

public enum GravityDirection
{
    Down,
    Right,
    Up,
    Left
    
}

public static class Gravity
{
    public static UnityEvent<Vector2> OnGravityChanged = new UnityEvent<Vector2>();
    public static UnityEvent OnGravityChangeEnd = new UnityEvent();

    public static Vector2 VectorDir;
    public static GravityDirection GravityDir;

    private static Vector2 m_NewDir;

    private static float m_TurnSpeed = 2f;

    private static float m_X;
    private static float m_Y;

    private static bool m_IsGravityChange = false;

    public static float TurnSpeed => m_TurnSpeed;
    public static Vector2 NewDir => m_NewDir;

    public static void Start()
    {
        VectorDir = new Vector2(0, -1);
        GravityDir = GravityDirection.Down;
    }

    public static void Up()
    {
        GravityDir = GravityDirection.Up;
        m_NewDir = new Vector2(0, 1);
        ChangeGravity();
    }

    public static void Down()
    {
        GravityDir = GravityDirection.Down;
        m_NewDir = new Vector2(0, -1);
        ChangeGravity();
    }

    public static void Left()
    {
        GravityDir = GravityDirection.Left;
        m_NewDir = new Vector2(-1, 0);
        ChangeGravity();
    }

    public static void Right()
    {
        GravityDir = GravityDirection.Right;
        m_NewDir = new Vector2(1, 0);
        ChangeGravity();
    }

    public static void TurnLeft()
    {
        m_NewDir = Quaternion.Euler(0, 0, 90) * VectorDir;

        if ((int)GravityDir < 3) GravityDir++;
        else GravityDir = (GravityDirection)0;
        ChangeGravity();
    }

    public static void TurnRight()
    {
        m_NewDir = Quaternion.Euler(0, 0, -90) * VectorDir;

        if ((int)GravityDir > 0) GravityDir--;
        else GravityDir = (GravityDirection)3;
        ChangeGravity();
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
        if (m_NewDir.x > m_X)
        {
            m_X += m_TurnSpeed * Time.deltaTime;
        }
        else if (m_NewDir.x < m_X)
        {
            m_X -= m_TurnSpeed * Time.deltaTime;
        }

        if (m_NewDir.y > m_Y)
        {
            m_Y += m_TurnSpeed * Time.deltaTime;
        }
        else if (m_NewDir.y < m_Y)
        {
            m_Y -= m_TurnSpeed * Time.deltaTime;
        }

        if ((m_NewDir - new Vector2(m_X, m_Y)).magnitude < 0.1f)
        {
            VectorDir = m_NewDir;
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


