using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelObject : MonoBehaviour, ITakenDamage
{
	[SerializeField]
	private BoxCollider2D	_boxCollider2D;
	[SerializeField]
	private GameObject		_view;
	[SerializeField]
	private ParticleSystem	_particleSystem;

	public void TakeDamage()
	{
		_view.SetActive(false);
		_boxCollider2D.enabled = false;

		_particleSystem.Play();

		StartCoroutine(DestroyAfterParticleEffect());
	}

	private IEnumerator DestroyAfterParticleEffect()
	{
		while (_particleSystem.isPlaying)
		{
			yield return null;
		}

		Destroy(gameObject);
	}
}
