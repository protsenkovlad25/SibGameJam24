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
			Vector2 moveDirection = Vector2.right * _parameters.Speed;

			float offsetY = Mathf.Sin(Time.time * _parameters.Frequency) * _parameters.Amplitude;
			Vector2 sinOffset = new Vector2(0f, offsetY);

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
		public float Speed		= 1f;
		public float Amplitude	= 1f;
		public float Frequency	= 1f;
	}
}
