using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSceneLoader : SceneLoader
{
	[ContextMenu("Load next level")]
	public void LoadNextLevel()
	{
		Scene currentScene = SceneManager.GetActiveScene();
		int currentSceneIndex = currentScene.buildIndex;

		int currentLevel = currentSceneIndex / _sceneVariants;
		if(currentLevel == _lastLevelIndex)
		{
			LoadLevel(0);
		}
		else
		{
			LoadLevel(( currentLevel + 1 ) * _sceneVariants + Random.Range(0, _sceneVariants));
		}
	}
}
