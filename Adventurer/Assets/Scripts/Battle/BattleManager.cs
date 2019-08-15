using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class BattleManager : MonoBehaviour
{
    public List<GameObject> targets;

    public BattleManagerConnector connector;
    public SkillSO skill;
    public SkillEffects skillEffects;
    public EnemyAttackSO enemyAttack;
    public System.Type pt;

    public string targetType;

    private void Awake()
    {
        skillEffects = GetComponent<SkillEffects>();
        pt = skillEffects.GetType();
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
    }
}
