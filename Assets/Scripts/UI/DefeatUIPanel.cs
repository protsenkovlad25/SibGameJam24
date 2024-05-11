using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefeatUIPanel : UIPanel
{
	protected override void OnHideComplete()
	{
		_levelSceneLoader.LoadMenu();
	}

	public override void Show()
	{
		base.Show();
		SoundManager.Instance.PlayEffect(PoolType.UI, "LevelFailed", transform.position);
	}
}
