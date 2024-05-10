using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, ITakenDamage
{
	[SerializeField]
	private SpriteRenderer  _view;
	[SerializeField]
	private ParticleSystem  _particleSystem;
    [SerializeField]
    private ComplexParticleSystem _complexParticleSystem;

    [SerializeField]
	private int             _hP         = 1;

	private Camera          _mainCamera;
	protected bool          _isActive;


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
                if (_view != null && _view.isVisible)
                {
                    Plane[] planes = GeometryUtility.CalculateFrustumPlanes(_mainCamera);

                    Bounds bounds = _view.bounds;

                    _isActive = GeometryUtility.TestPlanesAABB(planes, bounds);
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

	public void TakeDamage()
	{
		RemoveHP(1);
	}

	private void RemoveHP(int value)
	{
		_hP -= value;
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
		while (_particleSystem.isPlaying)
		{
			yield return null;
		}

		Destroy(gameObject);
	}
}
