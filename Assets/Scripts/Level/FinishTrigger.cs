using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTrigger : MonoBehaviour, ITriggerable
{
	public void Initialize()
	{
	}
    private void Update()
    {
		if (Input.GetKeyDown(KeyCode.K))
        {
			Hero.HeroTransform.gameObject.SetActive(false);
			ActivateTrigger();
        }
    }

    public void ActivateTrigger()
	{
		EventManager.LevelComplete();
		Camera.main.GetComponent<CameraController>().enabled = false;
	}
}
