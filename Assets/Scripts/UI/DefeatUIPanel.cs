using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefeatUIPanel : UIPanel
{
	protected override void OnHideComplete()
	{
		_levelSceneLoader.LoadMenu();
	}
}
