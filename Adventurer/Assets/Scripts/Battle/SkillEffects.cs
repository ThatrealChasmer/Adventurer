using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillEffects : MonoBehaviour
{
    public GameObject target;
    public void Focus()
    {
        target.GetComponent<Player>().stats.RestoreStamina(30);
    }

    public void Steal()
    {
        Debug.Log("Ekusuproosioon!");
    }
}
