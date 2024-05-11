using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallConfigurator : MonoBehaviour
{
    [SerializeField] bool m_IsHorizontal;
    [SerializeField] List<Sprite> m_Sprites;

    [SerializeField] Sprite m_AngleSprite;

    [SerializeField] bool m_IsAngle = false;

    private void OnValidate()
    {
        if(m_Sprites!=null)
        {
            if(m_Sprites.Count>0)
            {
                GetComponentInChildren<SpriteRenderer>().sprite = m_Sprites[UnityEngine.Random.Range(0, m_Sprites.Count)];
                
                if (m_IsHorizontal && !m_IsAngle)
                    GetComponentInChildren<SpriteRenderer>().transform.eulerAngles = new Vector3(0, 0, 90);
                else if(!m_IsAngle)
                    GetComponentInChildren<SpriteRenderer>().transform.eulerAngles = new Vector3(0, 0, 0);

                if (m_AngleSprite != null && m_IsAngle)
                {
                    GetComponentInChildren<SpriteRenderer>().sprite = m_AngleSprite;
                }
            }
        }
    }
}
