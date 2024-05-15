using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSceneLoader :MonoBehaviour
{
	List<LevelConfigData> m_LevelConfigs;

    private void Awake()
    {
        Init();
    }
    void Init()
    {
        m_LevelConfigs = new List<LevelConfigData>();
        m_LevelConfigs.AddRange(Resources.LoadAll<LevelConfigData>("LevelConfigs"));

        LevelSceneLoader.Init(m_LevelConfigs);

        Debug.Log(m_LevelConfigs.Count);
    }

    public void StartNewGame()
	{

		PlayerData.InitData(Resources.LoadAll<HeroConfig>("")[0]);
        LevelSceneLoader.LoadLevel(1);// + Random.Range(0, _sceneVariants));
	}
}
