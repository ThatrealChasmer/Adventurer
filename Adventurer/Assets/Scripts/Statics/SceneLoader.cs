﻿using UnityEngine.SceneManagement;

public static class SceneLoader
{
    public static void Load(string name)
    {
        SceneManager.LoadScene(name);
    }
}
