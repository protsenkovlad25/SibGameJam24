using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
	[SerializeField]
	private SpriteRenderer	_view;
	[SerializeField]
	private ParticleSystem	_particles;

	[SerializeField]
	private int				_hP			= 1;

	public virtual SpriteRenderer GetView()
	{
		return _view;
	}

	public virtual void SetView(Sprite sprite, Color color)
	{
		_view.sprite = sprite;
		_view.color = color;
	}
}
