using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSceneLoader : SceneLoader
{
	[SerializeField]
	private Button _playButton;

	private void OnEnable()
	{
		_playButton.onClick.AddListener(OnPlayButtonClick);
	}

	private void OnDisable()
	{
		_playButton.onClick.RemoveListener(OnPlayButtonClick);
	}

	private void OnPlayButtonClick()
	{
		LoadLevel(1);// + Random.Range(0, _sceneVariants));
	}
}
