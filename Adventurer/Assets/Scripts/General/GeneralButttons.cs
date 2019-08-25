using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralButttons : MonoBehaviour
{
    public void LoadScene(string scene)
    {
        SceneLoader.Load(scene);
    }
}
