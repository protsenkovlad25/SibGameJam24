using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private float m_MaxFallSpeed;
    [SerializeField] private float m_SpeedIncreaseTime;
    [SerializeField] private float m_MoveSpeed;

    private float m_FallSpeed;
    private float m_Time;

    private void Start()
    {
        PlayerInput.OnMove.AddListener(Move);
        GravityDirection.OnGravityChanged.AddListener(GravityChanged);

        m_FallSpeed = 0;
        m_Time = 0;

        GravityDirection.Down();
    }

    private void Fall()
    {
        transform.position += new Vector3(GravityDirection.Direction.x, GravityDirection.Direction.y, 0) * m_FallSpeed * Time.deltaTime;
    }

    private void Move(Vector2 dir)
    {
        transform.position += new Vector3(dir.x, dir.y, 0) * m_MoveSpeed * Time.deltaTime;
    }

    private void GravityChanged(Vector2 dir)
    {
        m_Time = 0;
        m_FallSpeed = 0;
    }

    private void IncreaseSpeed()
    {
        if (m_Time < m_SpeedIncreaseTime)
        {
            m_Time += Time.deltaTime;
            m_FallSpeed += m_MaxFallSpeed / m_SpeedIncreaseTime * Time.deltaTime;
        }
    }

    private void Update()
    {
        IncreaseSpeed();
        Fall();
    }
}
