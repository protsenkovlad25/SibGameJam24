using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : Enemy
{
	[SerializeField]
	private SpriteRenderer  _spriteRenderer;
	[SerializeField]
	private GameObject      _projectilePrefab;
	[SerializeField]
	private float			_t					= .5f;

	private Transform       _target;

	public Transform Target { get => _target; set => _target = value; }

	private void Start()
	{
		StartCoroutine(ShootCoroutine());
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

                    m_IsActive = GeometryUtility.TestPlanesAABB(planes, bounds);
                    if (m_IsActive)
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
                        if (isWall) m_IsActive = false;
                    }
                }
            }
        }


        if (m_IsActive)
		{
			Vector3 targetPosition = _target != null ? _target.position : Vector3.zero;

			transform.right = targetPosition - transform.position;
		}
	}

    private IEnumerator ShootCoroutine()
	{
		while (true)
		{
			yield return new WaitForSeconds(_t);

			if (m_IsActive)
			{
				Instantiate(_projectilePrefab, transform.position, transform.rotation);
			}
		}
	}
}
