using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] private Transform m_Start;
    [SerializeField] private Transform m_End;

    bool m_IsEnded = false;

    public Transform Start => m_Start;
    public Transform End => m_End;

    float m_TimeFromEnd = 0;

    public bool IsEnded => m_TimeFromEnd > 3;

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
