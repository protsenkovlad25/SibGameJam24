using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelUIPanel : UIPanel
{
	protected override void OnHideComplete()
	{
		_levelSceneLoader.LoadNextLevel();
	}
}
