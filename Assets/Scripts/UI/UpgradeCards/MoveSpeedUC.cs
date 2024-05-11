using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpeedUC : UpgradeCard
{
    private readonly float m_MoveSpeedValue = .4f;

    public override string Description => $"+{m_MoveSpeedValue * 100}% к Скорости движения";

    public override void Activate()
    {
        PlayerData.HeroData.MoveSpeed += PlayerData.HeroData.MoveSpeed * m_MoveSpeedValue;

        base.Activate();
    }
}
