using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCreationController : MonoBehaviour
{
    public GameObject nameField;
    public GameObject str;
    public GameObject def;
    public GameObject per;
    public GameObject intel;
    public GameObject spd;
    public GameObject luck;
    public GameObject sparePoints;

    public PlayerStatistics stats;

    bool inc;

    public int startingPoints;
    public int pointsLeft;

    private void Start()
    {
        pointsLeft = startingPoints;
        sparePoints.GetComponent<Text>().text = pointsLeft.ToString();
        str.GetComponent<Text>().text = stats.strength.ToString();
        def.GetComponent<Text>().text = stats.defense.ToString();
        per.GetComponent<Text>().text = stats.perception.ToString();
        intel.GetComponent<Text>().text = stats.intelligence.ToString();
        spd.GetComponent<Text>().text = stats.speed.ToString();
        luck.GetComponent<Text>().text = stats.luck.ToString();
    }

    public void Inc(bool increment)
    {
        inc = increment;
    }

    public void ChangeStat(string stat)
    {
        int amount = 1;

        if (!inc)
        {
            amount = -amount;
        }

        switch (stat)
        {
            case "strength":
                stats.strength += amount;
                str.GetComponent<Text>().text = stats.strength.ToString();
                break;
            case "defense":
                stats.defense += amount;
                def.GetComponent<Text>().text = stats.defense.ToString();
                break;
            case "perception":
                stats.perception += amount;
                per.GetComponent<Text>().text = stats.perception.ToString();
                break;
            case "intelligence":
                stats.intelligence += amount;
                intel.GetComponent<Text>().text = stats.intelligence.ToString();
                break;
            case "speed":
                stats.speed += amount;
                spd.GetComponent<Text>().text = stats.speed.ToString();
                break;
            case "luck":
                stats.luck += amount;
                luck.GetComponent<Text>().text = stats.luck.ToString();
                break;
        }

        pointsLeft -= amount;

        sparePoints.GetComponent<Text>().text = pointsLeft.ToString();
    }

    public void Confirm(string name)
    {
        stats.playerName = nameField.GetComponent<InputField>().text;
        stats.CalculateStats();
        SceneLoader.Load(name);
    }
}
