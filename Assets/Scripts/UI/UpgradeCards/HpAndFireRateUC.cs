using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpAndFireRateUC : UpgradeCard
{
    private readonly int m_HpValue = 5;
    private readonly float m_FireRateValue = .5f;

    public override string Description => $"-{m_HpValue} от Макс. HP\n+{m_FireRateValue * 100}% к Скорострельности";

    public override void Activate()
    {
        PlayerData.HeroData.MaxHealth -= m_HpValue;
        PlayerData.HeroData.Delay -= PlayerData.HeroData.Delay * m_FireRateValue;

        if (PlayerData.HeroData.Delay < 0)
            PlayerData.HeroData.Delay = 0;

        base.Activate();
    }
}
