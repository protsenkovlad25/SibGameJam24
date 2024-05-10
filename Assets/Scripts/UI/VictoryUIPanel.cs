using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryUIPanel : UIPanel
{
	protected override void OnHideComplete()
	{
		_levelSceneLoader.LoadCredits();
	}
}
