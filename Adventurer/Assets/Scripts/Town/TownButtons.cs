using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TownButtons: MonoBehaviour
{
    public PlayerStatistics stats;
    public Text nameText;

    private void Start()
    {
        nameText.text = stats.playerName;
    }

    public void LoadScene(string name)
    {
        if(name == "Hall")
        {
            SceneLoader.Load("PlayerCreation");
        }

        if(name == "Battle" && stats.playerName != null)
        {
            SceneLoader.Load(name);
        }
    }
}
