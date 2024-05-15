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
			GameObject prefab = levelConfigData.StaticEnemyPrefab.gameObject;
			enemy.SetView(prefab);
        }

		foreach (PursuingEnemy enemy in _pursuingEnemies)
		{
			GameObject prefab = levelConfigData.PursuingEnemyPrefab.gameObject;
			enemy.SetView(prefab);
            enemy.Target = playerTransform;
		}

		foreach (SinusoidEnemy enemy in _sinusoidEnemies)
		{
			GameObject prefab = levelConfigData.SinusoidEnemyPrefab.gameObject;
			enemy.SetView(prefab.gameObject);
        }

		foreach (ShootingEnemy enemy in _shootingEnemies)
		{
			GameObject prefab = levelConfigData.ShootingEnemyPrefab.gameObject;
			enemy.SetView(prefab);
            enemy.Target = playerTransform;
			Debug.Log("SetShooting target player");
		}
	}
}
