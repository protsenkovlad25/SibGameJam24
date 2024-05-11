using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSceneLoader : SceneLoader
{
	[SerializeField]
	private NextLevelUIPanel    _nextLevelUIPanel;
	[SerializeField]
	private VictoryUIPanel      _victoryUIPanel;

	public static int                 _currentLevel = 0;

	public void Initialize(NextLevelUIPanel nextLevelUIPanel, VictoryUIPanel victoryUIPanel)
	{
		_nextLevelUIPanel = nextLevelUIPanel;
		_victoryUIPanel = victoryUIPanel;

		Debug.Log("Level - " + _currentLevel);

		PlayerData.Level = _currentLevel;
	}

	public void LoadNextLevel()
	{
		_currentLevel++;
		LoadLevel(( _currentLevel+1));// * _sceneVariants + Random.Range(0, _sceneVariants));
	}

	public void FinishLevel()
	{
		if (_currentLevel == _lastLevelIndex)
		{
			_victoryUIPanel.Show();
		}
		else
		{
			_nextLevelUIPanel.Show();
		}
	}
}
