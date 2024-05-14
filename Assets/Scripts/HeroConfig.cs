using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new HeroData",menuName = "HeroData",order = 51)]
public class HeroConfig : ScriptableObject
{
    [SerializeField] HeroData m_HeroData;

    public HeroData HeroData => m_HeroData;
}
