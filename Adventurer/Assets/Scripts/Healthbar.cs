using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthbar : MonoBehaviour
{
    private EnemyStatistsics healthSystem;

    public void Initiate()
    {
        healthSystem = gameObject.GetComponentInParent<EnemyStatistsics>();
        healthSystem.OnEnemyHealthChanged += k;
        k();
    }

    private void k()
    {
        transform.Find("Bar").localScale = new Vector3(healthSystem.GetHealthPercent(), 1);
    }
}
