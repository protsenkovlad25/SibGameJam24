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

	private int                 _currentLevel;

	public void Initialize(NextLevelUIPanel nextLevelUIPanel, VictoryUIPanel victoryUIPanel)
	{
		_nextLevelUIPanel = nextLevelUIPanel;
		_victoryUIPanel = victoryUIPanel;

		Scene currentScene = SceneManager.GetActiveScene();
		int currentSceneIndex = currentScene.buildIndex;
		_currentLevel = currentSceneIndex / (_sceneVariants + 1);

		PlayerData.Level = _currentLevel;
	}

	public void LoadNextLevel()
	{

		LoadLevel(( _currentLevel + 1 ) * _sceneVariants + Random.Range(0, _sceneVariants));
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
