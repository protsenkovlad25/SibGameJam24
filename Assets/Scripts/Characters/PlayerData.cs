using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerData
{
    public static int Level { get; set; }

    public static HeroData HeroData;
    public static WeaponData WeaponData;
    public static LevelConfigData LevelConfig;

    public static float FallingDistance;

    public static void InitData(HeroConfig config)
    {
        HeroData = config.HeroData;
        Level = 1;
        FallingDistance = 0;
    }

    public static  void NextLevel()
    {
        Level++;
        LevelSceneLoader.LoadLevel(Level);
    }
}
