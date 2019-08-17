using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthbar : MonoBehaviour
{
    private EnemyStatistsics parent;
    void Awake()
    {
        parent = transform.parent.gameObject.GetComponent<EnemyStatistsics>();
        parent.OnEnemyHealthChanged += HealthChanged;
    }

    void HealthChanged()
    {
        transform.GetChild(0).localScale = new Vector3(parent.GetHealthPercent(), 1);
    }
}
