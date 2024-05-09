using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
	[SerializeField]
	private SpriteRenderer _view;

	[SerializeField]
	private int _hP;

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
