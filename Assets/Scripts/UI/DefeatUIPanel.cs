using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefeatUIPanel : UIPanel
{
	private LevelSceneLoader _levelSceneLoader;

	public void Initialize(LevelSceneLoader levelSceneLoader)
	{
		_levelSceneLoader = levelSceneLoader;
	}

	protected override void OnHideComplete()
	{
		_levelSceneLoader.LoadMenu();
	}
}
