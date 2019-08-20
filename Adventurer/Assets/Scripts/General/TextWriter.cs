using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextWriter : MonoBehaviour
{
    Coroutine typing;

    public Text textField;

    public float delay;
    public string fullText;
    string currentText;

    public bool isTyping;

    public void StartTyping()
    {
        typing = StartCoroutine(WriteText());
    }

    IEnumerator WriteText()
    {
        isTyping = true;
        for(int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            textField.text = currentText;
            yield return new WaitForSeconds(delay);
        }
        isTyping = false;
    }

    public void Skip()
    {
        StopCoroutine(typing);
        textField.text = fullText;
        isTyping = false;
    }
}
