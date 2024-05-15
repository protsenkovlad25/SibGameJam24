using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRateUC : UpgradeCard
{
    private readonly float m_Value = .1f;

    public override string Description => $"+{m_Value * 100}% к Скорострельности";

    public override void Activate()
    {
        PlayerData.HeroData.Delay -= PlayerData.HeroData.Delay * m_Value;

        if (PlayerData.HeroData.Delay < 0)
            PlayerData.HeroData.Delay = 0;

        base.Activate();
    }
}
