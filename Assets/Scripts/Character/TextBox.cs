using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextBox : MonoBehaviour
{
    [SerializeField]
    [TextArea]
    private List<string> textLines;

    private int lineIndex;
    private bool hasStarted;
    private TMP_Text text;
    private CanvasGroup group;

    private void Start()
    {
        text = GetComponent<TMP_Text>();
        group = GetComponent<CanvasGroup>();
        group.alpha = 0f;
    }

    public void SetChosenWord()
    {
        string chosenWord = WordCardsManager.Instance.GetWordAtIndex(0);
        if (chosenWord != null)
        {
            textLines[1] = chosenWord;
        }
        else
        {
            Debug.LogWarning("Chosen word is null or textLines array does not have an index 1.");
        }
    }

    public void StartText() {
        if (!hasStarted)
        {
            lineIndex = 0;
            text.SetText(textLines[lineIndex]);
            group.alpha = 1;
            hasStarted = true;
        }
        else if (lineIndex < textLines.Count)
        {
            text.SetText(textLines[lineIndex++]);
            SetChosenWord();
        }
        else { 
            group.alpha = 0f;
            hasStarted = false;
        }
    }

    

      
}
