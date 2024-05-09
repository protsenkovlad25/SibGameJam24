using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
	[SerializeField]
	private Rigidbody2D		_rigidbody2D;
	[SerializeField]
	private SpriteRenderer	_view;

	[SerializeField]
	private float			_speed			= 1f;
	[SerializeField]
	private float			_damage			= 1f;

	private Camera			_mainCamera;
	private bool			_isActive		= true;

	protected virtual void Awake()
	{
		_mainCamera = Camera.main;
	}

    protected virtual void Update()
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

	private void FixedUpdate()
	{
		if(_isActive)
		{
			_rigidbody2D.velocity = transform.right * _speed;
		}
		else
		{
			Destroy(gameObject);
		}
	}
}
