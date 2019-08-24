using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class BattleManager : MonoBehaviour
{
    public List<GameObject> targets = new List<GameObject>();

    public BattleInfoSO battleInfo;
    public BattleManagerConnector connector;
    public SkillSO skill;
    public SkillEffects skillEffects;
    public EnemyAttackSO enemyAttack;
    public EnemyAttackEffects eaEffects;
    public System.Type pt;
    public System.Type et;

    public TurnSystem turnSystem;
    public MenuSwapper ms;

    public GameObject menu;
    public GameObject endBattle;

    public string targetType;

    public PlayerStatistics playerStats;

    private void Awake()
    {
        skillEffects = GetComponent<SkillEffects>();
        pt = skillEffects.GetType();
        eaEffects = GetComponent<EnemyAttackEffects>();
        et = eaEffects.GetType();
        playerStats.GetStats();
        for(int i = 0; i < playerStats.statArray.Length; i++)
        {
            battleInfo.oldStats[i] = playerStats.statArray[i];
        }
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
            for(int i = 0; i < battleInfo.statChange.Length; i++)
            {
                battleInfo.statChange[i] += connector.skill.statChange[i];
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
            for (int i = 0; i < battleInfo.statChange.Length; i++)
            {
                battleInfo.statChange[i] += connector.skill.statChange[i];
            }
        }
        else if(targetType == "Player")
        {
            enemyAttack = connector.enemyAttack;
            foreach (GameObject target in targets)
            {
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

    public void EndBattle(bool win)
    {
        if(win)
        {
            playerStats.ChangeStats(battleInfo.statChange);
            menu.SetActive(false);
            endBattle.SetActive(true);
            ms.currentMenu = endBattle.transform.GetChild(0).gameObject;
        }
    }
}
