using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealUC : UpgradeCard
{
    public override string Description => $"Heal {m_Value} HP";

    public override void Activate()
    {
        PlayerData.HeroData.Health += (int)m_Value;

        base.Activate();
    }
}
