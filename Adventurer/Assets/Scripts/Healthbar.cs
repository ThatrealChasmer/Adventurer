using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthbar : MonoBehaviour
{
    private EnemyHealthSystem healthSystem;

    public void Start()
    {
        this.healthSystem = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyHealthSystem>();
        healthSystem.OnEnemyHealthChanged += k;
    }

    private void k(object sender, System.EventArgs e)
    {
        transform.Find("Bar").localScale = new Vector3(healthSystem.GetHealthPercent(), 1);
    }
}
