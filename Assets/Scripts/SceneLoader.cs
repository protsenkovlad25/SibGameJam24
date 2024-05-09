using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class SceneLoader : MonoBehaviour
{
	protected readonly int _sceneVariants	= 5;
	protected readonly int _lastLevelIndex	= 4;

	public virtual void LoadLevel(int level)
	{
		SceneManager.LoadScene(level);
	}
}
