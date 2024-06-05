using System.Collections.Generic;
using UnityEngine;

public class LevelConfigurator : MonoBehaviour
{
    [SerializeField] private LevelGenerator m_LevelGenerator;
    
    [SerializeField] private float m_GameLength;
    [SerializeField] private float m_DeltaLevelChange;
    [SerializeField] private float m_Procent;

    public void Init()
    {
        PlayerData.GameLength = m_GameLength;

        m_LevelGenerator.Init();
    }

    private void FixedUpdate()
    {
        if (PlayerData.Level < 5)
        {
            if (PlayerData.FallingDistance > m_DeltaLevelChange * PlayerData.Level)
            {
                PlayerData.NextLevel();
            }
        }
    }
}
