using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealUC : UpgradeCard
{
    private readonly int m_Value = 1;

    public override string Description => $"Восстановить {m_Value} HP";

    public override void Activate()
    {
        PlayerData.HeroData.Health += m_Value;

        base.Activate();
    }
}
