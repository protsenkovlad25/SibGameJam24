using DG.Tweening;
using UnityEngine;

public class HeroWeapon : MonoBehaviour
{
    [SerializeField] private Projectile m_Projectile;
    [SerializeField] private GameObject m_Char;
    [SerializeField] private Transform m_Muzzle;
    [SerializeField] private Transform m_ArtParent;

    [SerializeField] float m_Range;
    [SerializeField] float m_Delay;
    [SerializeField] float m_Spread;
    [SerializeField] float m_BulletsCount;

    float m_CurrentDelay;

    private Camera m_Camera;

    public void Init()
    {
        m_Camera = Camera.main;

        CalcRotation();

        LoadData();
    }

    private void LoadData()
    {
        m_Delay = PlayerData.HeroData.Delay;
        m_Range = PlayerData.HeroData.Range;
        m_Spread = PlayerData.HeroData.Spread;
        m_BulletsCount = PlayerData.HeroData.BulletsCount;
    }

    Vector2 GetMousePosition()
    {
        Vector3 result = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return result;
    }

    void CalcRotation()
    {
        Vector3 mousePos = GetMousePosition();

        float angle = Vector3.SignedAngle(new Vector3(1,0),
            mousePos - transform.position,
            new Vector3(0, 0, 1));

        transform.eulerAngles = new Vector3(0, 0, angle);
        if (transform.localEulerAngles.z > 90 && transform.localEulerAngles.z < 270)
        {
            GetComponentInChildren<SpriteRenderer>().flipY = m_Char.GetComponentInChildren<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponentInChildren<SpriteRenderer>().flipY = m_Char.GetComponentInChildren<SpriteRenderer>().flipX = false;
        }
    }
    void AnimateShoot()
    {
        Sequence s = DOTween.Sequence();


        float time = m_Delay / 10;

        if (time > .05f) time = .05f;

        if (GetComponentInChildren<SpriteRenderer>().flipY)
        {
            s.Append(m_ArtParent.DOLocalRotate(new Vector3(0, 0, -15), time));
        }
        else
        {
            s.Append(m_ArtParent.DOLocalRotate(new Vector3(0, 0, 15), time));
        }

        s.Join(m_ArtParent.transform.DOLocalMoveX(-.12f, time));

        s.Append(m_ArtParent.DOLocalRotate(new Vector3(0, 0, 0), time*3));
        s.Join(m_ArtParent.transform.DOLocalMoveX(0, time * 3));
    }
    private void Shoot()
    {
        m_CurrentDelay = m_Delay;

        m_Muzzle.GetComponent<ComplexParticleSystem>().PlayParticle();
        AnimateShoot();

        for (int i = 0; i < m_BulletsCount; i++)
        {
            var proj = Instantiate(m_Projectile);

            proj.transform.position = m_Muzzle.transform.position;

            proj.transform.parent = GetComponentInParent<Hero>().transform;

            proj.GetComponent<HeroProjectile>().SetRange(m_Range);


            proj.transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z + Random.Range(-m_Spread, m_Spread));
        }

        SoundManager.Instance.PlayEffect(PoolType.Weapon, "Player_Shoot.rpp-00" + Random.Range(1,6), m_Camera.transform.position);
    }
    private void Update()
    {
        CalcRotation();

        if (m_CurrentDelay > 0) m_CurrentDelay -= Time.deltaTime;

        if(Input.GetMouseButton(0) && m_CurrentDelay <=0)
            Shoot();
    }
}
