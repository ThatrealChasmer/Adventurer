using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuItem : MonoBehaviour
{
    public SkillSO skill = null;
    public Text text;
    public GameObject icon;

    public BattleManagerConnector connector;
    public GameObject selectionManager;

    private void Start()
    {
        selectionManager = GameObject.Find("SelectionManager");
    }

    public void Fill(SkillSO skill)
    {
        this.skill = skill;
        text.text = skill.skillName;
        icon.GetComponent<Image>().sprite = skill.icon;
        transform.GetChild(0).GetComponent<Button>().onClick.AddListener(OnUse);
    }

    /*
    public void Fill(SpellSO spell)
    {

    }

    public void Fill(ItemSO item)
    {

    }*/

    public void OnUse()
    {
        connector.skill = skill;
        connector.targetType = skill.targetType;
        selectionManager.GetComponent<SelectionManager>().selections = skill.targets;
        selectionManager.GetComponent<SelectionManager>().SetSelection(true);
    }
}
