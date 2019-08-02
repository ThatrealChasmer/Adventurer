using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCreationController : MonoBehaviour
{
    public GameObject nameTag;
    public GameObject statTag;
    public GameObject indicator;
    GameObject pointsField;
    GameObject confirm;

    public int startingPoints;
    public int pointsLeft;

    public int currentIndex;
    public GameObject currentStat;

    public bool onConfirm = false;

    public List<string> stats = new List<string>();
    public List<int> statValues = new List<int>();
    public List<GameObject> statFields = new List<GameObject>();
    

    // Start is called before the first frame update
    void Start()
    {
        pointsLeft = startingPoints;
        bool isLocked = true;
        FieldInfo[] fields = typeof(StatsTemplate.Stats).GetFields();
        foreach(var field in fields)
        {
            if(field.Name == "strength")
            {
                isLocked = false;
            }

            if(isLocked == false)
            {
                stats.Add(field.Name);
            }
        }

        foreach(string stat in stats)
        {
            statValues.Add(1);
        }

        RenderMenu();
        currentIndex = 0;

        SizeIndicator(statTag);

        MoveIndicator(statFields[currentIndex]);

        indicator.SetActive(true);


    }

    // Update is called once per frame
    void Update()
    {
        if (((Input.GetKeyDown(KeyCode.UpArrow) && currentIndex > 0) || (Input.GetKeyDown(KeyCode.DownArrow) && currentIndex < stats.Count - 1)) && onConfirm == false)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && currentIndex > 0)
            {
                currentIndex--;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && currentIndex < stats.Count - 1)
            {
                currentIndex++;
            }
            MoveIndicator(statFields[currentIndex]);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) && statValues[currentIndex] > 1)
            {
                statValues[currentIndex]--;
                pointsLeft++;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) && pointsLeft > 0)
            {
                statValues[currentIndex]++;
                pointsLeft--;
            }
            UpdateStat(statFields[currentIndex], statValues[currentIndex]);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && currentIndex == stats.Count-1)
        {
            onConfirm = true;
            SizeIndicator(confirm);
            MoveIndicator(confirm);
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow) && onConfirm == true)
        {
            onConfirm = false;
            SizeIndicator(statTag);
            MoveIndicator(statFields[statFields.Count - 1]);
        }
        else if(Input.GetKeyDown(KeyCode.Return) && onConfirm == true)
        {
            PlayerStats.playerStats.strength = statValues[0];
            PlayerStats.playerStats.defense = statValues[1];
            PlayerStats.playerStats.perception = statValues[2];
            PlayerStats.playerStats.inteligence = statValues[3];
            PlayerStats.playerStats.speed = statValues[4];
            PlayerStats.playerStats.luck = statValues[5];

            PlayerStats.CalculateStats();

            SceneManager.LoadScene("TestMenu");
        }
        
    }

    void RenderMenu()
    {
        GameObject menuItem = Instantiate(nameTag, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 150, gameObject.transform.position.z), Quaternion.identity, gameObject.transform);
        menuItem.name = nameTag.name;

        for (int i = 0; i < stats.Count; i++)
        {
            menuItem = Instantiate(statTag, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 120 - (i * statTag.GetComponent<RectTransform>().sizeDelta.y + 5), gameObject.transform.position.z), Quaternion.identity, gameObject.transform);
            menuItem.name = stats[i] + "Field";
            menuItem.transform.GetChild(0).GetComponent<Text>().text = stats[i];
            menuItem.transform.GetChild(1).GetComponent<Text>().text = statValues[i].ToString();
            statFields.Add(menuItem);
        }

        confirm = Instantiate(nameTag, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 100, gameObject.transform.position.z), Quaternion.identity, gameObject.transform);
        confirm.name = "Confirm";
        confirm.GetComponent<Text>().text = "Confirm";

        pointsField = Instantiate(menuItem, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 150, gameObject.transform.position.z), Quaternion.identity, gameObject.transform);
        pointsField.name = "pointsField";
        pointsField.transform.GetChild(0).GetComponent<Text>().text = "Points left:";
        pointsField.transform.GetChild(1).GetComponent<Text>().text = pointsLeft.ToString();
    }

    void UpdateStat(GameObject stat, int amount)
    {
        stat.transform.GetChild(1).GetComponent<Text>().text = amount.ToString();
        pointsField.transform.GetChild(1).GetComponent<Text>().text = pointsLeft.ToString();
    }

    void SizeIndicator(GameObject menuItem)
    {
        indicator.GetComponent<RectTransform>().sizeDelta = menuItem.GetComponent<RectTransform>().sizeDelta;
    }

    void MoveIndicator(GameObject field)
    {
        Vector3 target = field.transform.position;
        indicator.transform.position = target;
    }
}
