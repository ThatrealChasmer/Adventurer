using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Consumable Recipe", menuName = "Recipe/Consumable")]
public class ConsumableRecipeSO : ScriptableObject
{
    public ConsumableSO item;

    public List<ItemSO> materials;
    public List<ConsumableSO> ingredients;

    public int[] mAmounts;
    public int[] iAmounts;
}
