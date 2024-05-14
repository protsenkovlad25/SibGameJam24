using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    #region GameStateEvents
    public static UnityEvent OnLevelComplete= new UnityEvent();
    public static UnityEvent OnGameOver = new UnityEvent();

    public static void LevelComplete()
    {
        OnLevelComplete.Invoke();
    }
    public static void GameOver()
    {
        OnGameOver.Invoke();
    }
    #endregion
}
