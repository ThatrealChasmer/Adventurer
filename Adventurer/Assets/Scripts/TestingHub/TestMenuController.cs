using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TestMenuController : MonoBehaviour
{
    public GameObject menuItem;
    public GameObject indicator;

    public List<CustomEnums.TestMenuOptions> options = new List<CustomEnums.TestMenuOptions>();

    public int cols;
    public int rows;

    public int currentIndex;
    public int minIndex;
    public int maxIndex;

    // Start is called before the first frame update
    void Start()
    {
        options.Add(CustomEnums.TestMenuOptions.Battle);
        options.Add(CustomEnums.TestMenuOptions.QuestHall);
        currentIndex = 0;
        RenderMenuItems(currentIndex);
        MoveIndicator(currentIndex);
        indicator.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && currentIndex - cols >= 0)
            {
                currentIndex -= 2;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) && currentIndex % cols < cols - 1 && currentIndex + 1 < options.Count)
            {
                currentIndex += 1;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && currentIndex + cols < options.Count)
            {
                currentIndex += 2;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && currentIndex % cols > 0)
            {
                currentIndex -= 1;
            }

            if(currentIndex > maxIndex)
            {
                RenderMenuItems(currentIndex - (rows - 1) * cols - currentIndex % cols);
            }
            else if(currentIndex < minIndex)
            {
                RenderMenuItems(currentIndex - currentIndex % cols);
            }

            MoveIndicator(currentIndex);
        }

        if(Input.GetKeyDown(KeyCode.Return))
        {
            indicator.SetActive(false);
            SceneManager.LoadScene(options[currentIndex].ToString());
        }
    }

    void RenderMenuItems(int index)
    {
        foreach (Transform child in gameObject.transform)
        {
            if (child.gameObject.CompareTag("MenuItem"))
            {
                GameObject.Destroy(child.gameObject);
            }
        }
        int renderedItems = 0;
        for (int i = index; i < index + (cols*rows); i++)
        {
            if (i < options.Count)
            {
                GameObject opt = Instantiate(menuItem, new Vector3((gameObject.transform.position.x - 100 * (cols - 1)) + (200 * (i % cols)), (gameObject.transform.position.y + 27.5f * (rows - 1)) - 55 * (((i - index) - (i - index) % cols) / cols), gameObject.transform.position.z), Quaternion.identity, gameObject.transform);
                opt.name = options[i].ToString();
                opt.transform.GetChild(0).GetComponent<Text>().text = options[i].ToString();
                renderedItems++;
            }
        }
        minIndex = index;
        maxIndex = index + renderedItems - 1;
    }
    
    public void MoveIndicator(int index)
    {
        Vector3 target = GameObject.Find(options[index].ToString()).transform.position;
        indicator.transform.position = target;
    }
}
