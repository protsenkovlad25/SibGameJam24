using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSceneLoader :MonoBehaviour
{
	private void Awake()
    {
        Init();
    }
    void Init()
    {
        LevelSceneLoader.Init();
    }

    public void StartNewGame()
	{
		PlayerData.InitData(Resources.LoadAll<HeroConfig>("")[0]);
        LevelSceneLoader.LoadLevel(1);// + Random.Range(0, _sceneVariants));
	}
}
