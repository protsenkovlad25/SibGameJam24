using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelConfigLoader : MonoBehaviour
{
	[SerializeField]
	private LevelConfigData _levelConfigData;

	public void UpdateEnemies(EnemyContainer enemyContainer)
	{
		enemyContainer.SetEnemies(_levelConfigData);
	}
}
