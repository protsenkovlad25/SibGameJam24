using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class SceneLoader : MonoBehaviour
{
	[SerializeField]
	protected int _sceneVariants = 5;

	public virtual void LoadLevel(int level)
	{
		SceneManager.LoadScene(level);
	}
}
