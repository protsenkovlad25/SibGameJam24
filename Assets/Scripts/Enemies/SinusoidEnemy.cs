using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinusoidEnemy : Enemy
{
	[SerializeField] private Rigidbody2D m_Rigidbody2D;
	[SerializeField] private ParametersDataModel		m_Parameters;
	[SerializeField] private AudioSource	m_AudioSource;

	private float m_Time;

	public ParametersDataModel Parameters { get => m_Parameters; set => m_Parameters =  value ; }

	private void FixedUpdate()
	{
		if (m_IsActive)
		{
			m_AudioSource.mute = false;
			m_Time += Time.deltaTime;

			if (CheckWall())
				Reflect();

			m_Rigidbody2D.velocity = GetDirection()*m_Parameters.Speed;
		}
		else
		{
			m_AudioSource.mute = true;

			m_Rigidbody2D.velocity = Vector2.zero;
		}
	}
	void Reflect()
	{
		if (m_Parameters.Direction == Direction.Up)
		{
			m_Parameters.Direction = Direction.Down;
		}
		else if (m_Parameters.Direction == Direction.Down)
		{
			m_Parameters.Direction = Direction.Up;
		}
		else if (m_Parameters.Direction == Direction.Right)
		{
			m_Parameters.Direction = Direction.Left;
		}
		else if (m_Parameters.Direction == Direction.Left)
		{
			m_Parameters.Direction = Direction.Right;
		}
	}
	Vector2 GetDirection()
	{

		Vector2 direction = Vector2.zero;

		if (m_Parameters.Direction == Direction.Up)
		{
			direction = Vector2.up;
		}
		else if (m_Parameters.Direction == Direction.Down)
		{
			direction = Vector2.down;
		}
		else if (m_Parameters.Direction == Direction.Right)
		{
			direction = Vector2.right;
		}
		else if (m_Parameters.Direction == Direction.Left)
		{
			direction = Vector2.left;
		}
		return direction;

	}
	bool CheckWall()
    {
		List<RaycastHit2D> hits = new List<RaycastHit2D>();
		hits.AddRange(Physics2D.RaycastAll(transform.position, GetDirection(), .5f));

		return hits.Exists(x => x.collider.gameObject.TryGetComponent<Obstacle>(out _)) || hits.Exists(x => x.collider.gameObject.layer == 7);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
		switch(m_Parameters.Direction)
        {
			case Direction.Up:
				break;
			case Direction.Down:
				break;
			case Direction.Right:
				break;
			case Direction.Left:
				break;
		}
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
    }

    [Serializable]
	public class ParametersDataModel
	{
		public float		Speed		= 1f;
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
