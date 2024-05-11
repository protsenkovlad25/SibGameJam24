using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedIncreaseUC : UpgradeCard
{
    private readonly float m_SpeedIncreaseTimeValue = 2;

    public override string Description => $"����� ������� �� ����. �������� ������� ��������� �� {m_SpeedIncreaseTimeValue} �������";

    public override void Activate()
    {
        PlayerData.HeroData.SpeedIncreaseTime += m_SpeedIncreaseTimeValue;

        base.Activate();
    }
}
