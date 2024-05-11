using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxHealthUC : UpgradeCard
{
    private readonly int m_Value = 1;

    public override string Description => $"+{m_Value} к Макс. HP";

    public override void Activate()
    {
        PlayerData.HeroData.MaxHealth += m_Value;
        PlayerData.HeroData.Health += m_Value;

        base.Activate();
    }
}
