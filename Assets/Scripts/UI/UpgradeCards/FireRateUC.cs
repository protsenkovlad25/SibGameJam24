using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRateUC : UpgradeCard
{
    private readonly float m_Value = .1f;

    public override string Description => $"+{m_Value * 100}% к Скорострельности";

    public override void Activate()
    {
        PlayerData.WeaponData.Delay -= PlayerData.WeaponData.Delay * m_Value;

        if (PlayerData.WeaponData.Delay < 0)
            PlayerData.WeaponData.Delay = 0;

        base.Activate();
    }
}
