using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSceneLoader : SceneLoader
{
	[SerializeField]
	private UIButton _playButton;

	private void OnEnable()
	{
		_playButton.ClickEvent += OnClickEvent;
	}

	private void OnDisable()
	{
		_playButton.ClickEvent -= OnClickEvent;
	}

	private void OnClickEvent()
	{
		LevelSceneLoader._currentLevel = 0;

        LoadLevel(1);// + Random.Range(0, _sceneVariants));
	}
}
