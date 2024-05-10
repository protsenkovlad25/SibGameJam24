using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxHealthUC : UpgradeCard
{
    public override string Description => $"Increase Max Health on {m_Value}";

    public override void Activate()
    {
        PlayerData.HeroData.MaxHealth += (int)m_Value;
    }
}
