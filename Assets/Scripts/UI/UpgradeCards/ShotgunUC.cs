using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunUC : UpgradeCard
{
    private readonly float m_BulletValue = 3;
    private readonly float m_SpreadValue = 15;
    private readonly float m_RangeValue = .5f;

    public override string Description => $"������������� +{m_BulletValue} ����\n+{m_SpreadValue} �������� � ��������\n-{m_RangeValue * 100}% � ��������� ��������";

    public override void Activate()
    {
        PlayerData.WeaponData.BulletsCount += m_BulletValue;
        PlayerData.WeaponData.Spread += m_SpreadValue;
        PlayerData.WeaponData.Range -= PlayerData.WeaponData.Range * m_RangeValue;

        base.Activate();
    }
}
