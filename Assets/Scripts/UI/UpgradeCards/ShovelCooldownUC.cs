using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelCooldownUC : UpgradeCard
{
    private readonly float m_ShovelCDValue = 2;

    public override string Description => $"Время перезарядки лопаты меньше на {m_ShovelCDValue} секунды";

    public override void Activate()
    {
        PlayerData.HeroData.ShovelCooldown -= m_ShovelCDValue;
        
        if (PlayerData.HeroData.ShovelCooldown < 0)
            PlayerData.HeroData.ShovelCooldown = 0;

        base.Activate();
    }
}
