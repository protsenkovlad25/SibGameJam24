using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelTimeUC : UpgradeCard
{
    private readonly float m_ShovelTimeValue = 3;

    public override string Description => $"������ ��������� ���������� � ������� �� {m_ShovelTimeValue} ������� ������";

    public override void Activate()
    {
        PlayerData.HeroData.ShovelTime += m_ShovelTimeValue;

        base.Activate();
    }
}
