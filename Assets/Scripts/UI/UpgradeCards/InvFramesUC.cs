using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvFramesUC : UpgradeCard
{
    private readonly float m_InvFramesValue = 1;

    public override string Description => $"+{m_InvFramesValue} ������ � ������������ ����� ��������� �����";

    public override void Activate()
    {
        PlayerData.HeroData.InvFramesTime += m_InvFramesValue;

        base.Activate();
    }
}
