using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour, ITakenDamage
{
	[SerializeField]
	private ParticleSystem _particleSystem;

	public void TakeDamage()
	{
		
	}
}
