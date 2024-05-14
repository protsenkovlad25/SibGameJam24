using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class GameEntryPoint : MonoBehaviour
{
    [SerializeField]
    private LevelConfigLoader   _levelConfigLoader;
    [SerializeField]
    private EnemyContainer      _enemyContainer;
    [SerializeField]
    private FinishTrigger       _finishTrigger;
    [SerializeField]
    private LevelCanvas         _levelCanvas;
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
		_finishTrigger.Initialize();
        _nextLevelUIPanel.Initialize(_levelCanvas);
        _defeatUIPanel.Initialize(_levelCanvas);
        _victoryUIPanel.Initialize(_levelCanvas);


		Gravity.Start();
        PlayerInput.Init();

        _playerTransform.GetComponent<Hero>().Init();
    }

    private void Update()
    {
        Gravity.Update();
    }
}
