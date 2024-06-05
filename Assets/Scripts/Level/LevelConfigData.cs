using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LevelConfigData : ScriptableObject
{
	public int LevelId;

	public EnemyView StaticEnemyPrefab;
	public EnemyView PursuingEnemyPrefab;
	public EnemyView SinusoidEnemyPrefab;
	public EnemyView ShootingEnemyPrefab;

	public AudioClip LevelMusic;
	public AudioClip Ambience;

	public List<Sprite> WallsSprites;
	public List<Sprite> BackWallsSprites;
}
