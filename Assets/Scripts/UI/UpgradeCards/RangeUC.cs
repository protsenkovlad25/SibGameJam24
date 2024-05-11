using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeUC : UpgradeCard
{
    private readonly float m_RangeValue = .33f;

    public override string Description => $"+{m_RangeValue * 100}% к Дистанции стрельбы";

    public override void Activate()
    {
        PlayerData.WeaponData.Range += PlayerData.WeaponData.Range * m_RangeValue;

        base.Activate();
    }
}
