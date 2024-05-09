using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : Enemy
{
	[SerializeField]
	private SpriteRenderer  _spriteRenderer;
	[SerializeField]
	private GameObject      _projectilePrefab;
	[SerializeField]
	private float			_t					= 1f;

	private Transform       _target;

	public Transform Target { get => _target; set => _target = value; }

	private void Start()
	{
		StartCoroutine(ShootCoroutine());
	}

	public override void Update()
	{
		base.Update();
		if(_isActive)
		{
			Vector3 targetPosition = _target != null ? _target.position : Vector3.zero;

			transform.right = targetPosition - transform.position;
		}
	}

	private IEnumerator ShootCoroutine()
	{
		while (true)
		{
			yield return new WaitForSeconds(_t);

			if (_isActive)
			{
				Instantiate(_projectilePrefab, transform.position, transform.rotation);
			}
		}
	}
}
