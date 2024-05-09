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
}
