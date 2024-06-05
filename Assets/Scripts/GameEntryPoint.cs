using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class GameEntryPoint : MonoBehaviour
{
    [SerializeField] private EnemyContainer _enemyContainer;
    [SerializeField] private FinishTrigger _finishTrigger;
    [SerializeField] private LevelConfigurator _levelConfigurator;

    [Header("UI")]
    [SerializeField] private LevelCanvas _levelCanvas;
    [SerializeField] private DefeatUIPanel _defeatUIPanel;
    [SerializeField] private VictoryUIPanel _victoryUIPanel;
    [SerializeField] private NextLevelUIPanel _nextLevelUIPanel;

    [SerializeField] private Transform _playerTransform;

    private void Awake()
    {
        _enemyContainer.GetBaseEnemies();
        _enemyContainer.SetEnemies(PlayerData.LevelConfig, _playerTransform);

        SoundManager.Instance.PlayMusic(PlayerData.LevelConfig.LevelMusic);
        SoundManager.Instance.PlayAmbience(PlayerData.LevelConfig.Ambience);

        _finishTrigger.Initialize();
        _nextLevelUIPanel.Initialize(_levelCanvas);
        _defeatUIPanel.Initialize(_levelCanvas);
        _victoryUIPanel.Initialize(_levelCanvas);

        _levelConfigurator.Init();

		Gravity.Start();
        PlayerInput.Init();

        _playerTransform.GetComponent<Hero>().Init();
    }

    private void Update()
    {
        Gravity.Update();
    }
}
