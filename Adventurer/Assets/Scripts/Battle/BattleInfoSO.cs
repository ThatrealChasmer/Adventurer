using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BattleInfo", menuName = "BattleInfo")]
public class BattleInfoSO : ScriptableObject
{
    public List<EnemySO> enemies;
    public List<ItemSO> items;

}
