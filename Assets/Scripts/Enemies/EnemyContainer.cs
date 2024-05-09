using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyContainer : MonoBehaviour
{
	private Enemy[] _staticEnemies;

	public void GetBaseEnemies()
	{
		_staticEnemies = GetComponentsInChildren<StaticEnemy>();
	}

	public void SetEnemies(LevelConfigData levelConfigData)
	{
		foreach (var enemy in _staticEnemies)
		{
			enemy.SetView(levelConfigData.StaticEnemyPrefab.GetView().sprite, levelConfigData.StaticEnemyPrefab.GetView().color);
		}
	}
}
