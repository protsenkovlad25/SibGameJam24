using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LevelConfigData : ScriptableObject
{
	public StaticEnemy		StaticEnemyPrefab;
	public PursuingEnemy	PursuingEnemyPrefab;
	public SinusoidEnemy	SinusoidEnemyPrefab;
}
