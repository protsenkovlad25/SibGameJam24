using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunUC : UpgradeCard
{
    private readonly float m_BulletValue = 3;
    private readonly float m_SpreadValue = 15;
    private readonly float m_RangeValue = .5f;

    public override string Description => $"Выстреливаешь +{m_BulletValue} пули\n+{m_SpreadValue} градусов к Разбросу\n-{m_RangeValue * 100}% к Дистанции стрельбы";

    public override void Activate()
    {
        PlayerData.WeaponData.BulletsCount += m_BulletValue;
        PlayerData.WeaponData.Spread += m_SpreadValue;
        PlayerData.WeaponData.Range -= PlayerData.WeaponData.Range * m_RangeValue;

        base.Activate();
    }
}
