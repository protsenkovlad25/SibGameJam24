using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursuingEnemy : Enemy
{
	[SerializeField]
	private Rigidbody2D     _rigidbody2D;
	[SerializeField]
	private SpriteRenderer	_spriteRenderer;
	[SerializeField]
	public float			_speed				= 5f;

	private Camera			_mainCamera;
	private Transform		_target;
	private bool			_isActive;

	private void Awake()
	{
		_mainCamera = Camera.main;
	}

	public void Update()
	{
		if (_mainCamera != null)
		{
			if (_spriteRenderer != null && _spriteRenderer.isVisible)
			{
				Plane[] planes = GeometryUtility.CalculateFrustumPlanes(_mainCamera);

				Bounds bounds = _spriteRenderer.bounds;

				_isActive = GeometryUtility.TestPlanesAABB(planes, bounds);
			}
		}
	}

	public void FixedUpdate()
	{
		if (_isActive)
		{
			Vector3 targetPosition = _target != null ? _target.position : Vector3.zero;

			Vector3 direction = (targetPosition - transform.position).normalized;

			_rigidbody2D.velocity = direction * _speed;
		}
	}

	public void SetTarget(Transform target)
	{
		_target = target;
	}
}
