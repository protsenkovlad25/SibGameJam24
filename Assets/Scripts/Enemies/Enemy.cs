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

	private Camera          _mainCamera;
	protected bool          _isActive;

	private void Awake()
	{
		_mainCamera = Camera.main;
	}

	public void Update()
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
