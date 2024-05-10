using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
	private UIPanel _nextLevelUIPanel;

	public void Initialize(UIPanel nextLevelUIPanel)
	{
		_nextLevelUIPanel = nextLevelUIPanel;
	}

	public void OnFinishTrigger()
	{
		_nextLevelUIPanel.Show();
	}
}
