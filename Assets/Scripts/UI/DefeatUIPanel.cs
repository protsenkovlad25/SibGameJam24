using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefeatUIPanel : UIPanel
{
    private void Awake()
    {
        EventManager.OnGameOver.AddListener(OnHideComplete);
    }
    protected override void OnHideComplete()
    {
        LevelSceneLoader.LoadMenu();
    }

	public override void Show()
	{
		base.Show();
		SoundManager.Instance.PlayEffect(PoolType.UI, "LevelFailed", transform.position);
	}
}
