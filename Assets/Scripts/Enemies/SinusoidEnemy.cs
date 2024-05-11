using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinusoidEnemy : Enemy
{
	[SerializeField]
	private Rigidbody2D				_rigidbody2D;

	[SerializeField]
	private ParametersDataModel		_parameters;

	private float                   _time;

	public ParametersDataModel		Parameters { get => _parameters; set => _parameters =  value ; }

	private void FixedUpdate()
	{
		if (_isActive)
		{
			Vector2 direction = Vector2.zero;

			if (_parameters.Direction == Direction.Up)
			{
				direction = Vector2.up;
			}
			else if (_parameters.Direction == Direction.Down)
			{
				direction = Vector2.down;
			}
			else if (_parameters.Direction == Direction.Right)
			{
				direction = Vector2.right;
			}
			else if (_parameters.Direction == Direction.Left)
			{
				direction = Vector2.left;
			}

			_time += Time.deltaTime;
			_rigidbody2D.velocity = GetProjectileVelocity(direction, _parameters.Speed, _time, _parameters.Frequency, _parameters.Amplitude);
		}
		else
		{
			_rigidbody2D.velocity = Vector2.zero;
		}
	}

	private Vector2 GetProjectileVelocity(Vector2 forward, float speed, float time, float frequency, float amplitude)
	{
		Vector2 up = new Vector2(-forward.y, forward.x);
		float upSpeed = Mathf.Cos(time * frequency) * amplitude * frequency;

		return up * upSpeed + forward * speed;
	}
    public override void Update()
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
                    if (_isActive)
                    {
                        var Hits = Physics2D.RaycastAll(transform.position, (Hero.HeroTransform.position - transform.position).normalized, (Hero.HeroTransform.position - transform.position).magnitude);
                        bool isWall = false;
                        foreach (var hit in Hits)
                        {
                            if (hit.collider.gameObject.layer == 7)
                            {
                                isWall = true;
                                break;
                            }
                        }
                        if (isWall) _isActive = false;
                    }
                }
            }
        }
    }

    [Serializable]
	public class ParametersDataModel
	{
		public float		Speed		= 1f;
		public float		Amplitude	= 1f;
		public float		Frequency	= 1f;
		public Direction	Direction;
	}

	public enum Direction
	{
		Up,
		Down,
		Right,
		Left
	}
}
