using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BattleInfo", menuName = "BattleInfo")]
public class BattleInfoSO : ScriptableObject
{
    public List<EnemySO> enemies;
    public List<ItemSO> items;

    public int[] oldStats = { 0, 0, 0, 0, 0, 0};
    public int[] statChange = { 0, 0, 0, 0, 0, 0 };

    public void Clear()
    {
        enemies.Clear();
        items.Clear();
        for(int i = 0; i < statChange.Length; i++)
        {
            statChange[i] = 0;
        }
    }
}
