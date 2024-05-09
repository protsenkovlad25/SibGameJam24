using DG.Tweening;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private float m_MaxFallSpeed;
    [SerializeField] private float m_SpeedIncreaseTime;
    [SerializeField] private float m_MoveSpeed;
    [SerializeField] private float m_GravityChangeCD;

    private float m_FallSpeed;
    private float m_Time;

    private void Start()
    {
        PlayerInput.OnMove.AddListener(Move);
        Gravity.OnGravityChanged.AddListener(GravityChanged);
        Gravity.OnGravityChangeEnd.AddListener(GravityChangeEnd);

        m_FallSpeed = 0;
        m_Time = 0;
    }

    private void Fall()
    {
        transform.position += new Vector3(Gravity.VectorDir.x, Gravity.VectorDir.y, 0) * m_FallSpeed * Time.deltaTime;
    }

    private void Move(Vector2 dir)
    {
        transform.position += new Vector3(dir.x, dir.y, 0) * m_MoveSpeed * Time.deltaTime;
    }

    private void GravityChanged(Vector2 dir)
    {
        m_FallSpeed = m_MaxFallSpeed / 2;
        LookAt(dir, 1f / Gravity.TurnSpeed);
    }
    void LookAt(Vector2 dir, float time)
    {
        int targetRot = 0;
        switch(Gravity.GravityDir)
        {
            case GravityDirection.Left:
                targetRot = 270;
                break;
            case GravityDirection.Up:
                targetRot = 180;
                break;
            case GravityDirection.Down:
                targetRot = 0;
                break;
            case GravityDirection.Right:
                targetRot = 90;
                break;
        }
        transform.DORotate(new Vector3(0,0, targetRot), time);
    }

    private void GravityChangeEnd()
    {
        m_Time = m_SpeedIncreaseTime / 2;
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
