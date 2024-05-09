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
        LookAt(Gravity.NewDir, 1f / Gravity.TurnSpeed);
    }
    void LookAt(Vector2 dir, float time)
    {
        Debug.Log("Rotate");
        Vector3 startRot = transform.eulerAngles;
        transform.LookAt(transform.position + (Vector3)dir);

        Vector3 targetRot = transform.eulerAngles;

        Debug.Log("Rotate from " + startRot + " to "+ targetRot);

        transform.eulerAngles = startRot;
        transform.DORotate(new Vector3(0,0, targetRot.y), time);
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
