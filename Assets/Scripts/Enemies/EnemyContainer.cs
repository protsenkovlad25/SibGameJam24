using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyContainer : MonoBehaviour
{
	private StaticEnemy[]		_staticEnemies;
	private PursuingEnemy[]		_pursuingEnemies;

	public void GetBaseEnemies()
	{
		_staticEnemies = GetComponentsInChildren<StaticEnemy>();
		_pursuingEnemies = GetComponentsInChildren<PursuingEnemy>();
	}

	public void SetEnemies(LevelConfigData levelConfigData, Transform playerTransform)
	{
		foreach (var enemy in _staticEnemies)
		{
			enemy.SetView(levelConfigData.StaticEnemyPrefab.GetView().sprite, levelConfigData.StaticEnemyPrefab.GetView().color);
		}

		foreach (PursuingEnemy enemy in _pursuingEnemies)
		{
			enemy.SetView(levelConfigData.PursuingEnemyPrefab.GetView().sprite, levelConfigData.PursuingEnemyPrefab.GetView().color);
			enemy.SetTarget(playerTransform);
		}
	}
}
