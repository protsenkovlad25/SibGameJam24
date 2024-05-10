using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hero : MonoBehaviour, ITakenDamage
{
    public static UnityEvent<int> OnChangeHP = new UnityEvent<int>();
    public static UnityEvent OnActiveShovel = new UnityEvent();
    public static UnityEvent OnDie = new UnityEvent();

    public static bool IsShovel;

    [SerializeField] private float m_MaxFallSpeed;
    [SerializeField] private float m_SpeedIncreaseTime;
    [SerializeField] private float m_MoveSpeed;
    [SerializeField] private float m_GravityChangeCD;
    [SerializeField] private float m_InvFramesTime;
    [SerializeField] private float m_ShovelTime;
    [SerializeField] private float m_ShovelCooldown;
    [SerializeField] private int m_Health;

    private float m_FallSpeed;
    private float m_Time;

    private bool m_IsTakeDamage;

    private Timer m_GCDTimer;
    private Timer m_ShovelTimer;
    private Timer m_ShovelCDTimer;

    private GameObject m_FrontTrigger;

    private void Start()
    {
        PlayerInput.OnMove.AddListener(Move);
        Gravity.OnGravityChanged.AddListener(GravityChanged);
        Gravity.OnGravityChangeEnd.AddListener(GravityChangeEnd);
        OnActiveShovel.AddListener(ActiveShovel);

        GetComponentInChildren<FrontTrigger>().OnFrontTriggered = FrontTriggered;

        m_FrontTrigger = GetComponentInChildren<FrontTrigger>().gameObject;

        m_FallSpeed = 0;
        m_Time = 0;

        m_IsTakeDamage = true;
        IsShovel = false;
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
        m_FrontTrigger.SetActive(false);
        m_FallSpeed = m_MaxFallSpeed / 2;
        
        LookAt(dir, 1f / Gravity.TurnSpeed);

        m_GCDTimer = new Timer(m_GravityChangeCD);
        m_GCDTimer.OnTimesUp.AddListener(GravityCooldownEnd);
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
        m_FrontTrigger.SetActive(true);
        m_Time = m_SpeedIncreaseTime / 2;
    }

    private void GravityCooldownEnd()
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

        PlayerInput.LockMove();

        m_FallSpeed = 0;
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
        gameObject.SetActive(false);
        PlayerInput.Lock();

        OnDie?.Invoke();
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

    private void ActiveShovel()
    {
        IsShovel = true;
        
        m_FallSpeed = 0;

        m_ShovelTimer = new Timer(m_ShovelTime);
        m_ShovelTimer.OnTimesUp.AddListener(DisactiveShovel);
    }

    private void DisactiveShovel()
    {
        IsShovel = false;
        PlayerInput.Unlock();

        m_ShovelTimer = null;

        m_ShovelCDTimer = new Timer(m_ShovelCooldown);
        m_ShovelCDTimer.OnTimesUp.AddListener(ShovelCooldownEnd);

        m_Time = 0;
    }

    private void ShovelCooldownEnd()
    {
        m_ShovelCDTimer = null;
        PlayerInput.IsCanActiveShovel = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Obstacle>(out var obstacle))
        {
            TakeDamage();
            obstacle.TakeDamage();
            m_FallSpeed = 0;
            m_Time = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.TryGetComponent<ITakenDamage>(out var takenDamage))
            takenDamage.TakeDamage();
    }

    private void Update()
    {
        if (!IsShovel) IncreaseSpeed();
        Fall();

        m_GCDTimer?.Update();
        m_ShovelTimer?.Update();
        m_ShovelCDTimer?.Update();
    }
}
