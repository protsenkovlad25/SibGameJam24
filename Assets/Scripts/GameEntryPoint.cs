using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEntryPoint : MonoBehaviour
{
    [SerializeField]
    private LevelConfigLoader   _levelConfigLoader;
    [SerializeField]
    private EnemyContainer      _enemyContainer;

    [SerializeField]
    private Transform           _playerTransform;

    private void Awake()
    {
        //_enemyContainer.GetBaseEnemies();
        //_levelConfigLoader.UpdateEnemies(_enemyContainer, _playerTransform);

        Gravity.Start();
    }

    private void Update()
    {
        Gravity.Update();
    }
}
