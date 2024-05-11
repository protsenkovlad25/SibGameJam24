using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.RuleTile.TilingRuleOutput;

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

    public static Vector2 NewDir;

    private static float m_TurnSpeed = 2f;

    private static float m_X;
    private static float m_Y;

    private static bool m_IsGravityChange = false;

    private static Camera m_MainCamera;

    public static float TurnSpeed => m_TurnSpeed;

    public static void Start()
    {
        VectorDir = new Vector2(0, -1);
        GravityDir = GravityDirection.Down;
		m_MainCamera = Camera.main;

	}

    public static void TurnLeft()
    {
        NewDir = Quaternion.Euler(0, 0, 90) * VectorDir;

        if ((int)GravityDir < 3) GravityDir++;
        else GravityDir = (GravityDirection)0;
        ChangeGravity();
    }

    public static void TurnRight()
    {
        NewDir = Quaternion.Euler(0, 0, -90) * VectorDir;

        if ((int)GravityDir > 0) GravityDir--;
        else GravityDir = (GravityDirection)3;
        ChangeGravity();
    }
    private static void ChangeGravity()
    {
		SoundManager.Instance.PlayEffect(PoolType.Addictive, "gravity change.rpp-00" + Random.Range(1, 4), m_MainCamera.transform.position);
		m_IsGravityChange = true;

        m_X = VectorDir.x;
        m_Y = VectorDir.y;

        OnGravityChanged?.Invoke(NewDir);
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


