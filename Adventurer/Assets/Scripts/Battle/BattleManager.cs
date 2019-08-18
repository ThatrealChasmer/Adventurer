using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class BattleManager : MonoBehaviour
{
    public List<GameObject> targets = new List<GameObject>();

    public BattleManagerConnector connector;
    public SkillSO skill;
    public SkillEffects skillEffects;
    public EnemyAttackSO enemyAttack;
    public EnemyAttackEffects eaEffects;
    public System.Type pt;
    public System.Type et;

    public TurnSystem turnSystem;
    public MenuSwapper ms;

    public string targetType;

    private void Awake()
    {
        skillEffects = GetComponent<SkillEffects>();
        pt = skillEffects.GetType();
        eaEffects = GetComponent<EnemyAttackEffects>();
        et = eaEffects.GetType();
    }

    public void AddTarget(GameObject target)
    {
        targets.Add(target);
    }

    public void SetSkill()
    {
        skill = connector.skill;
    }

    public void ConfirmAttack()
    {
        targetType = connector.targetType;
        
        if(targetType == "Enemy")
        {
            foreach(GameObject target in targets)
            {
                target.GetComponent<EnemyStatistsics>().Take_Damage(connector.skill.damage);
                foreach(MethodInfo m in pt.GetMethods())
                {
                    if(m.Name == skill.name)
                    {
                        skillEffects.target = target;
                        skillEffects.Invoke(connector.skill.name, 0);
                    }
                }
            }
        }
        else if(targetType == "Self")
        {
            foreach(GameObject target in targets)
            {
                target.GetComponent<Player>().stats.TakeDamage(skill.damage);
                foreach (MethodInfo m in pt.GetMethods())
                {
                    if (m.Name == skill.name)
                    {
                        skillEffects.target = target;
                        skillEffects.Invoke(skill.name, 0);
                    }
                }
            }
        }
        else if(targetType == "Player")
        {
            enemyAttack = connector.enemyAttack;
            foreach (GameObject target in targets)
            {
                Debug.Log(targets.Count);
                Debug.Log(target.name);
                target.GetComponent<Player>().stats.TakeDamage(enemyAttack.damage);
                foreach (MethodInfo m in et.GetMethods())
                {
                    if (m.Name == enemyAttack.name)
                    {
                        eaEffects.target = target;
                        eaEffects.Invoke(skill.name, 0);
                    }
                }
            }
        }
        targets.Clear();
        ms.swapMenu("AfterAction");
    }
}
