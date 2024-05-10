using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTrigger : MonoBehaviour, ITriggerable
{
	protected LevelSceneLoader _levelSceneLoader;

	public void Initialize(LevelSceneLoader levelSceneLoader)
	{
		_levelSceneLoader = levelSceneLoader;
	}

	public void ActivateTrigger()
	{
		Camera.main.GetComponent<CameraController>().enabled = false;
		_levelSceneLoader.FinishLevel();
	}
}
