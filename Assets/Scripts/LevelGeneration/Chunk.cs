using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] private Transform m_Start;
    [SerializeField] private Transform m_End;

    private bool m_IsEnded = false;
    private float m_TimeFromEnd = 0;
    private List<WallConfigurator> m_Walls;
    private List<WallConfigurator> m_BackWalls;

    public Transform Start => m_Start;
    public Transform End => m_End;
    public bool IsEnded => m_TimeFromEnd > 3;
    public List<WallConfigurator> Walls => m_Walls;
    public List<WallConfigurator> BackWalls => m_BackWalls;

    public void Init()
    {
        m_Walls = new List<WallConfigurator>();
        m_BackWalls = new List<WallConfigurator>();

        foreach (Transform child in transform)
        {
            if (child.TryGetComponent<WallConfigurator>(out var wall))
            {
                if (wall.gameObject.layer == 7)
                    m_Walls.Add(wall);
                else
                    m_BackWalls.Add(wall);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<Hero>(out _))
            m_IsEnded= true;
    }
    private void Update()
    {
        if(m_IsEnded) 
        {
            m_TimeFromEnd += Time.deltaTime;
        }
    }
}
