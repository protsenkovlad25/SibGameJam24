using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerData
{
    public static int Level { get; set; }

    public static HeroData HeroData;
    public static WeaponData WeaponData;
    public static LevelConfigData LevelConfig;
    public static LevelConfigData NextLevelConfig;

    public static float FallingDistance;
    public static float GameLength;

    private static List<LevelConfigData> m_LevelConfigs;

    public static void InitData(HeroConfig config)
    {
        m_LevelConfigs = new List<LevelConfigData>();
        m_LevelConfigs.AddRange(Resources.LoadAll<LevelConfigData>("LevelConfigs"));

        HeroData = config.HeroData;
        Level = 1;
        LevelConfig = m_LevelConfigs[Level - 1];
        NextLevelConfig = m_LevelConfigs[Level];
        FallingDistance = 0;
    }

    public static void NextLevel()
    {
        Level++;
        LevelConfig = m_LevelConfigs[Level - 1];
        if (Level < 5) NextLevelConfig = m_LevelConfigs[Level];

        SoundManager.Instance.PlayMusic(LevelConfig.LevelMusic);
        SoundManager.Instance.PlayAmbience(LevelConfig.Ambience);
        //LevelSceneLoader.LoadLevel(Level);
    }
}
