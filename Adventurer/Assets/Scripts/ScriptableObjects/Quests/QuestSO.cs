using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quest", menuName = "Quest")]
public class QuestSO : ScriptableObject
{
    public bool completion = false;
    public EnemySO target;
    public int targetAmount;
    public int amount = 0;
    public int reward;


    public void Check(string name)
    {
        if (!completion && name.Equals(target.enemy_name))
        {
            amount++;
            if (amount >= targetAmount)
            {
                completion = true;
            }
        }
    }
}
