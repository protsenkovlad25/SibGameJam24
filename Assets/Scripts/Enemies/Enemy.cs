using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, ITakenDamage
{
	protected EnemyView m_View;

    protected int m_Hp = 1;

    protected Camera m_MainCamera;
	protected bool m_IsActive;


	private void Awake()
	{
		m_MainCamera = Camera.main;
	}

	public virtual void Update()
	{
		if (m_Hp > 0)
        {
            if (m_MainCamera != null)
            {
				if ((transform.position - Hero.HeroTransform.position).magnitude < 15)
				{
					if (m_View != null && m_View.Sprite.isVisible)
					{
						Plane[] planes = GeometryUtility.CalculateFrustumPlanes(m_MainCamera);

						Bounds bounds = m_View.Sprite.bounds;

						m_IsActive = GeometryUtility.TestPlanesAABB(planes, bounds);
						if(m_IsActive )
						{
							var Hits =  Physics2D.RaycastAll(transform.position, (Hero.HeroTransform.position - transform.position).normalized, (Hero.HeroTransform.position - transform.position).magnitude);
							bool isWall = false;
							foreach(var hit in Hits)
							{
								if(hit.collider.gameObject.layer == 7)
								{
									isWall = true;
									break;
								}
							}
							if(isWall) m_IsActive = false;
						}
					}
				}
            }
        }
	}

	public virtual GameObject GetView()
	{
		return m_View.gameObject;
	}

	public virtual void SetView(GameObject newView)
	{
		m_View = Instantiate(newView, transform).GetComponent<EnemyView>();

		m_View.Init();

		m_View.transform.localPosition = Vector3.zero;
		
	}
	public void TakeDamage()
	{
		RemoveHP(1);
	}

	private void RemoveHP(int value)
	{
		m_Hp -= value;

		if(m_Hp<=0)
        {
			Dead();
        }
	}
	void Dead()
	{
		m_IsActive = false;
		GetComponent<Collider2D>().enabled = false;

		m_View.Dead();

		StartCoroutine(DestroyAfterParticleEffect());
	}
	private void OnTriggerEnter2D(Collider2D collision)
    {
		if (collision.gameObject.GetComponent<ITakenDamage>() is ITakenDamage gamagable)
        {
            gamagable.TakeDamage();
        }
    }

	private IEnumerator DestroyAfterParticleEffect()
	{
		if(m_View.Particles != null)
        {
            while (m_View.Particles.IsPlaying)
            {
                yield return null;
            }
        }

		Destroy(gameObject);
	}
}
