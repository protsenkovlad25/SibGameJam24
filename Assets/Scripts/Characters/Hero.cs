using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hero : MonoBehaviour, ITakenDamage
{
    public static UnityEvent<int> OnChangeHP = new UnityEvent<int>();

    [SerializeField] private float m_MaxFallSpeed;
    [SerializeField] private float m_SpeedIncreaseTime;
    [SerializeField] private float m_MoveSpeed;
    [SerializeField] private float m_GravityChangeCD;
    [SerializeField] private float m_InvFramesTime;
    [SerializeField] private int m_Health;

    private float m_FallSpeed;
    private float m_Time;
    private bool m_IsTakeDamage = true;

    private Timer m_GCDTimer;

    private void Start()
    {
        PlayerInput.OnMove.AddListener(Move);
        Gravity.OnGravityChanged.AddListener(GravityChanged);
        Gravity.OnGravityChangeEnd.AddListener(GravityChangeEnd);

        GetComponentInChildren<FrontTrigger>().OnFrontTriggered = FrontTriggered;

        m_FallSpeed = 0;
        m_Time = 0;
    }

    private void LoadHeroData()
    {

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

        m_GCDTimer = new Timer(m_GravityChangeCD);
        m_GCDTimer.OnTimesUp.AddListener(CoolDownEnd);
    }

    private void LookAt(Vector2 dir, float time)
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

    private void CoolDownEnd()
    {
        m_GCDTimer = null;
        PlayerInput.IsCanChangeGravity = true;
    }

    private void IncreaseSpeed()
    {
        if (m_Time < m_SpeedIncreaseTime)
        {
            m_Time += Time.deltaTime;
            m_FallSpeed += m_MaxFallSpeed / m_SpeedIncreaseTime * Time.deltaTime;
        }
    } 

    private void FrontTriggered()
    {
        TakeDamage();
    }

    public void TakeDamage()
    {
        if (m_IsTakeDamage)
        {
            m_Health -= 1;
            OnChangeHP?.Invoke(m_Health);

            if (m_Health == 0)
            {
                m_IsTakeDamage = false;
                Die();
                return;
            }

            m_IsTakeDamage = false;
            StartCoroutine(InvincibilityFrames());
        }
    }

    private void Die()
    {

    }

    private IEnumerator InvincibilityFrames()
    {
        BlinkingAnim();

        yield return new WaitForSeconds(m_InvFramesTime);

        m_IsTakeDamage = true;
    }

    private void BlinkingAnim()
    {
        Sequence s = DOTween.Sequence();

        List<SpriteRenderer> sprites = new List<SpriteRenderer>();
        sprites.AddRange(GetComponentsInChildren<SpriteRenderer>());

        s.Append(sprites[0].DOFade(.3f, m_InvFramesTime / 6));
        s.Join(sprites[1].DOFade(.3f, m_InvFramesTime / 6));
        s.Append(sprites[0].DOFade(1f, m_InvFramesTime / 6));
        s.Join(sprites[1].DOFade(1f, m_InvFramesTime / 6));

        s.SetLoops(3);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<ITakenDamage>(out var takenDamage))
            takenDamage.TakeDamage();
    }

    private void Update()
    {
        IncreaseSpeed();
        Fall();

        m_GCDTimer?.Update();
    }
}
