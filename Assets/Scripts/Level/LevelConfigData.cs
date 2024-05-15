using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LevelConfigData : ScriptableObject
{
	public int LevelId;
	public StaticEnemy		StaticEnemyPrefab;
	public PursuingEnemy	PursuingEnemyPrefab;
	public SinusoidEnemy	SinusoidEnemyPrefab;
	public ShootingEnemy	ShootingEnemyPrefab;
	public AudioClip		LevelMusic;
	public AudioClip        Ambience;
}
