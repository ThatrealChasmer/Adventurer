using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowStatChange : MonoBehaviour
{
    public enum Stat
    {
        Strength,
        Defense,
        Perception,
        Intelligence,
        Speed,
        Luck
    }

    public BattleInfoSO bi;
    public PlayerStatistics ps;

    public Stat stat;

    public Text statNum;

    int index;

    void OnEnable()
    {
        ps.GetStats();
        switch(stat)
        {
            case Stat.Strength:
                index = 0;
                break;
            case Stat.Defense:
                index = 1;
                break;
            case Stat.Perception:
                index = 2;
                break;
            case Stat.Intelligence:
                index = 3;
                break;
            case Stat.Speed:
                index = 4;
                break;
            case Stat.Luck:
                index = 5;
                break;
        }

        if(bi.oldStats[index] != ps.statArray[index])
        {
            statNum.text = bi.oldStats[index].ToString() + " > " + ps.statArray[index].ToString();
        }
        else
        {
            statNum.text = ps.statArray[index].ToString();
        }
    }
}
