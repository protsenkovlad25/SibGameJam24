using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroProjectile : Projectile
{
    float m_Range;
    Vector3 m_StartPosition;

    public void SetRange(float range)
    {
        m_Range = range;
        m_StartPosition= transform.position;
    }

    protected override void Update()
    {
        base.Update();
        if(m_Range<(m_StartPosition - transform.position).magnitude) Destroy(gameObject);
    }
}
