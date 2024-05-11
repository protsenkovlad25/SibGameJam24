using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class SceneLoader : MonoBehaviour
{
	protected readonly int _sceneVariants		= 1;
	protected readonly int _lastLevelIndex		= 3;
	protected readonly int _menuSceneIndex		= 0;
	protected readonly int _creditsSceneIndex	= 4;

	public virtual void LoadLevel(int level)
	{
		SceneManager.LoadScene(level);
	}

	public void LoadMenu()
	{
		SceneManager.LoadScene(_menuSceneIndex);
	}

	public void LoadCredits()
	{
		SceneManager.LoadScene(_creditsSceneIndex);
	}
}
