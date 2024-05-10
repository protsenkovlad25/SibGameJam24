using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroProjectile : Projectile
{
    [SerializeField] ComplexParticleSystem m_CollisionParticles;
    float m_Range;
    Vector3 m_StartPosition;

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
        base.Disactivate();
    }
    protected override void Update()
    {
        base.Update();
        if(m_Range<(m_StartPosition - transform.localPosition).magnitude) Destroy(gameObject);
    }
}
