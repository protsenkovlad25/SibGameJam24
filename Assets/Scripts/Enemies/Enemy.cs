using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, ITakenDamage
{
	[SerializeField]
	private SpriteRenderer  _view;
	[SerializeField]
	private ParticleSystem  _particles;

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

	public virtual SpriteRenderer GetView()
	{
		return _view;
	}

	public virtual void SetView(Sprite sprite, Color color)
	{
		_view.sprite = sprite;
		_view.color = color;
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
			Destroy(gameObject);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ITakenDamage>() is ITakenDamage gamagable)
        {
            gamagable.TakeDamage();
        }
    }
}
