using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyContainer : MonoBehaviour
{
	private StaticEnemy[]		_staticEnemies;
	private PursuingEnemy[]		_pursuingEnemies;
	private SinusoidEnemy[]		_sinusoidEnemies;
	private ShootingEnemy[]		_shootingEnemies;

	public void GetBaseEnemies()
	{
		_staticEnemies = GetComponentsInChildren<StaticEnemy>();
		_pursuingEnemies = GetComponentsInChildren<PursuingEnemy>();
		_sinusoidEnemies = GetComponentsInChildren<SinusoidEnemy>();
		_shootingEnemies = GetComponentsInChildren<ShootingEnemy>();
	}

	public void SetEnemies(LevelConfigData levelConfigData, Transform playerTransform)
	{
		foreach (StaticEnemy enemy in _staticEnemies)
		{
			StaticEnemy prefab = levelConfigData.StaticEnemyPrefab;
			enemy.SetView(prefab.GetView().sprite, prefab.GetView().color);
		}

		foreach (PursuingEnemy enemy in _pursuingEnemies)
		{
			PursuingEnemy prefab = levelConfigData.PursuingEnemyPrefab;
			enemy.SetView(prefab.GetView().sprite, prefab.GetView().color);
			enemy.Target = playerTransform;
			enemy.Speed = prefab.Speed;
		}

		foreach (SinusoidEnemy enemy in _sinusoidEnemies)
		{
			SinusoidEnemy prefab = levelConfigData.SinusoidEnemyPrefab;
			enemy.SetView(prefab.GetView().sprite, prefab.GetView().color);
			enemy.Parameters = prefab.Parameters;
		}

		foreach (ShootingEnemy enemy in _shootingEnemies)
		{
			ShootingEnemy prefab = levelConfigData.ShootingEnemyPrefab;
			enemy.SetView(prefab.GetView().sprite, prefab.GetView().color);
			enemy.Target = playerTransform;
		}
	}
}
