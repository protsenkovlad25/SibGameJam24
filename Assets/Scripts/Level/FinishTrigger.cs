using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTrigger : MonoBehaviour, ITriggerable
{
	public void Initialize()
	{
	}

	public void ActivateTrigger()
	{
		EventManager.LevelComplete();
		Camera.main.GetComponent<CameraController>().enabled = false;
	}
}
