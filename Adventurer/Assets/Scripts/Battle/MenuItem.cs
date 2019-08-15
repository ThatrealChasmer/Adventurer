using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuItem : MonoBehaviour
{
    public SkillSO skill;
    public Text text;
    public GameObject icon;

    private void Start()
    {
        
    }

    public void Fill(SkillSO skill)
    {
        this.skill = skill;
        text.text = skill.skillName;
        icon.GetComponent<Image>().sprite = skill.icon;
    }

    /*
    public void Fill(SpellSO spell)
    {

    }

    public void Fill(ItemSO item)
    {

    }*/
}
