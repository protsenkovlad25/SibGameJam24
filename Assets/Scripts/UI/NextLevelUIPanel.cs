using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelUIPanel : UIPanel
{
	private LevelSceneLoader _levelSceneLoader;

	public void Initialize(LevelSceneLoader levelSceneLoader)
	{
		_levelSceneLoader = levelSceneLoader;
	}

	public override void Hide()
	{
		base.Hide();
		_levelSceneLoader.LoadNextLevel();
	}
}
