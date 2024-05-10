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
    private LevelSceneLoader    _levelSceneLoader;
    [SerializeField]
    private FinishTrigger       _finishTrigger;
    [SerializeField]
    private NextLevelUIPanel    _nextLevelUIPanel;
    [SerializeField]
    private DefeatUIPanel       _defeatUIPanel;
    [SerializeField]
    private VictoryUIPanel      _victoryUIPanel;

    [SerializeField]
    private Transform           _playerTransform;

    private void Awake()
    {
        _enemyContainer.GetBaseEnemies();
        _levelConfigLoader.UpdateEnemies(_enemyContainer, _playerTransform);
        _levelSceneLoader.Initialize(_nextLevelUIPanel, _victoryUIPanel);
		_finishTrigger.Initialize(_levelSceneLoader);
        _nextLevelUIPanel.Initialize(_levelSceneLoader);
        _defeatUIPanel.Initialize(_levelSceneLoader);

		Gravity.Start();
    }

    private void Update()
    {
        Gravity.Update();
    }
}
