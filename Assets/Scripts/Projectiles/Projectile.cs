using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
	[SerializeField]
	private Rigidbody2D		_rigidbody2D;
	[SerializeField]
	private SpriteRenderer	_view;

	[SerializeField]
	protected float			_speed			= 1f;
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

	protected virtual void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.TryGetComponent<ITakenDamage>(out var takenDamage))
		{
			takenDamage.TakeDamage();
			gameObject.SetActive(false);
        }
		else
        {
			int value = (PlayerData.Level)*5 + Random.Range(1,6);
			string result = value.ToString("D2");
			SoundManager.Instance.PlayEffect(PoolType.Weapon, "Walls_damage.rpp-0" + result, collision.GetContact(0).point);
			gameObject.SetActive(false);
        }
	}

	protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<ITakenDamage>(out var takenDamage))
        {
            takenDamage.TakeDamage();
			gameObject.SetActive(false);
        }
    }

	protected virtual void Disactivate()
	{

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
