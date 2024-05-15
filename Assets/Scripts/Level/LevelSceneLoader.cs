using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class LevelSceneLoader
{
    static List<LevelConfigData> m_LevelConfigs;
    public static void Init(List<LevelConfigData> configs)
    {
        m_LevelConfigs = new List<LevelConfigData>();
        m_LevelConfigs.AddRange(configs);
    }
    public static void LoadLevel(int level)
    {
        PlayerData.LevelConfig = m_LevelConfigs.Find(x => x.LevelId == level);



        SceneManager.LoadScene(level);
    }
    public static void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public static void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }
}
