using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelTimeUC : UpgradeCard
{
    private readonly float m_ShovelTimeValue = 3;

    public override string Description => $"Лопата позволяет оставаться в воздухе на {m_ShovelTimeValue} секунды дольше";

    public override void Activate()
    {
        PlayerData.HeroData.ShovelTime += m_ShovelTimeValue;

        base.Activate();
    }
}
