using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] private Transform m_Start;
    [SerializeField] private Transform m_End;

    public Vector3 Start => m_Start.position;
    public Vector3 End => m_End.position;
}
