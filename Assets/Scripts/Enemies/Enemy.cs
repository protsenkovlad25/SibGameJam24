using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, ITakenDamage
{
	[SerializeField]
	protected SpriteRenderer  _view;
	[SerializeField]
    protected ParticleSystem  _particleSystem;
    [SerializeField]
    protected ComplexParticleSystem _complexParticleSystem;

    [SerializeField]
    protected int             _hP         = 1;

    protected Camera          _mainCamera;
	protected bool          _isActive;

	public ComplexParticleSystem Particles => _complexParticleSystem;

	private void Awake()
	{
		_mainCamera = Camera.main;
	}

	public virtual void Update()
	{
		if (_hP > 0)
        {
            if (_mainCamera != null)
            {
				if ((transform.position - Hero.HeroTransform.position).magnitude < 15)
				{
					if (_view != null && _view.isVisible)
					{
						Plane[] planes = GeometryUtility.CalculateFrustumPlanes(_mainCamera);

						Bounds bounds = _view.bounds;

						_isActive = GeometryUtility.TestPlanesAABB(planes, bounds);
						if(_isActive )
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
							if(isWall) _isActive = false;
						}
					}
				}
            }
        }
	}

	public virtual GameObject GetView()
	{
		return _view.gameObject;
	}

	public virtual void SetView(GameObject newView)
	{
		_view.color = new Color(0,0,0,0);
		Instantiate(newView,_view.transform).transform.localPosition = Vector3.zero;
		
	}
	public virtual void SetParticles(ComplexParticleSystem newParticles)
	{
		var p = Instantiate(newParticles.gameObject, transform);
		p.transform.localPosition = Vector3.zero;
		Destroy(_complexParticleSystem.gameObject);
		_complexParticleSystem = p.GetComponent<ComplexParticleSystem>();
	}
	public void TakeDamage()
	{
		RemoveHP(1);
	}

	private void RemoveHP(int value)
	{
		_hP -= value;

		int number = Random.Range(1,6);
		SoundManager.Instance.PlayEffect(PoolType.Enemies, "Enemy_Damage_" + ( PlayerData.Level + 1 ) + ".rpp-00" + number, transform.position);

		if (_hP <= 0)
		{
			_isActive= false;
			_view.gameObject.SetActive(false);
			GetComponent<Collider2D>().enabled = false;

			if (_complexParticleSystem != null)
				_complexParticleSystem.PlayParticle();
			else
				_particleSystem?.Play();

			StartCoroutine(DestroyAfterParticleEffect());
		}
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
		if(_complexParticleSystem != null)
        {
            while (_complexParticleSystem.IsPlaying)
            {
                yield return null;
            }
        }
		else
        {
            while (_particleSystem.isPlaying)
            {
                yield return null;
            }
        }

		Destroy(gameObject);
	}
}
