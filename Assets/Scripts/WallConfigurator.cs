using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallConfigurator : MonoBehaviour
{
    [SerializeField] List<Sprite> m_Sprites;
    private void OnValidate()
    {
        if(m_Sprites!=null)
        {
            if(m_Sprites.Count>0)
            {
                GetComponentInChildren<SpriteRenderer>().sprite = m_Sprites[Random.Range(0, m_Sprites.Count)];
            }
        }
    }
}
