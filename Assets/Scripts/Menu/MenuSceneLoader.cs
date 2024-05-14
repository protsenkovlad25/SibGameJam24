using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSceneLoader : SceneLoader
{
	public void StartNewGame()
	{

		PlayerData.InitData(Resources.LoadAll<HeroConfig>("")[0]);
        LoadLevel(1);// + Random.Range(0, _sceneVariants));
	}
}
