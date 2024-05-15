using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAndSpreadUC : UpgradeCard
{
    private readonly int m_BulletValue = 1;
    private readonly float m_SpreadValue = 10;

    public override string Description => $"������������� +{m_BulletValue} ����\n������� +{m_SpreadValue} ��������";

    public override void Activate()
    {
        PlayerData.HeroData.BulletsCount += m_BulletValue;
        PlayerData.HeroData.Spread += m_SpreadValue;

        base.Activate();
    }
}
