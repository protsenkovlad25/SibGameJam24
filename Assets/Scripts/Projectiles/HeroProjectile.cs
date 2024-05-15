using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroProjectile : Projectile
{
    [SerializeField] ComplexParticleSystem m_CollisionParticles;
    float m_Range;
    Vector3 m_StartPosition;

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        PlayParticles();
        base.OnCollisionEnter2D(collision);
    }

    void PlayParticles()
    {
        var part = Instantiate(m_CollisionParticles.gameObject);
        part.transform.position = transform.position;
        part.transform.eulerAngles = transform.eulerAngles;
        part.GetComponent<ComplexParticleSystem>().PlayParticle();
    }

    public void SetRange(float range)
    {
        m_Range = range;
        m_StartPosition= transform.localPosition;
    }
    public void SetSpeed(float speed)
    {
    }
    protected override void Disactivate()
    {
        PlayParticles();
        Destroy(gameObject);
    }
    protected override void Update()
    {
        if(m_Range<(m_StartPosition - transform.localPosition).magnitude) Destroy(gameObject);
    }
}
