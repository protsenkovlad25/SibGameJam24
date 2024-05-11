using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelConfigLoader : MonoBehaviour
{
	[SerializeField]
	private LevelConfigData _levelConfigData;

	public void UpdateEnemies(EnemyContainer enemyContainer, Transform playerTransform)
	{
		enemyContainer.SetEnemies(_levelConfigData, playerTransform);
		SoundManager.Instance.PlayMusic(_levelConfigData.LevelMusic);
	}
}
