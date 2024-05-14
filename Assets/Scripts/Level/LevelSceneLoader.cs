using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class LevelSceneLoader
{
    public static void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }
    public static void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public static void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }
}
