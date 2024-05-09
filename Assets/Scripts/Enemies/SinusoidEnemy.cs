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

	public ParametersDataModel		Parameters { get => _parameters; set => _parameters =  value ; }

	private void FixedUpdate()
	{
		if (_isActive)
		{
			Vector2 moveDirection = Vector2.zero;
			Vector2 sinOffset = Vector2.zero;

			if (_parameters.Direction == Direction.Up || _parameters.Direction == Direction.Down)
			{
				moveDirection = Vector2.up * _parameters.Speed;
				sinOffset = Vector2.right * Mathf.Sin(Time.time * _parameters.Frequency) * _parameters.Amplitude;
			}
			else if (_parameters.Direction == Direction.Right || _parameters.Direction == Direction.Left)
			{
				moveDirection = Vector2.right * _parameters.Speed;
				sinOffset = Vector2.up * Mathf.Sin(Time.time * _parameters.Frequency) * _parameters.Amplitude;
			}

			Vector2 totalVelocity = moveDirection + sinOffset;
			_rigidbody2D.velocity = totalVelocity;
		}
		else
		{
			_rigidbody2D.velocity = Vector2.zero;
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
