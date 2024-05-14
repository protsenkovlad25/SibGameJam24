using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryUIPanel : UIPanel
{
    public void Awake()
    {
        
    }
    protected override void OnHideComplete()
	{
		LevelSceneLoader.LoadCredits();
	}

	public override void Show()
	{
		base.Show();
		SoundManager.Instance.PlayEffect(PoolType.UI, "LevelSuccessful.rpp", transform.position);
	}
}
