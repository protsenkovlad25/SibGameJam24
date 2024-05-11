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
	private float            _speed               = 1f;
	[SerializeField]
	private AudioSource		_audioSource;

	private Transform		_target;

	public Transform Target { get => _target; set => _target =  value ; }
	public float Speed { get => _speed; set => _speed =  value ; }

	public void FixedUpdate()
	{
		if (_isActive)
		{
			_audioSource.mute = false;

			Vector3 targetPosition = _target != null ? _target.position : Vector3.zero;

			GetComponentInChildren<Animator>().GetComponent<SpriteRenderer>().flipX = transform.position.x < targetPosition.x;

			Vector3 direction = (targetPosition - transform.position).normalized;

			_rigidbody2D.velocity = direction * _speed;
		}
		else
		{
			_audioSource.mute = true;
		}
	}
}
