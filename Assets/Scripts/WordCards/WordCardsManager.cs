using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WordCardsManager : MonoBehaviour
{
    public static WordCardsManager Instance { get; private set; }

    [SerializeField] private WordCard wordCard;
    private TextMeshProUGUI wordDisplayText;

    private List<string> wordList = new List<string>();

    private void Start()
    {
        Instance = this;
        wordDisplayText = GetComponentInChildren<TextMeshProUGUI>();
        SetWordCardText();

    }

    public void SetWordCardText()
    {
        wordDisplayText.text = wordCard.GetWord();
    }

    public void AddWordInList(string word)
    {
        word = wordCard.GetWord();
        wordList.Add(word);
    }

    public string GetWordAtIndex(int wordIndex)
    {
        if (wordIndex >= 0 && wordIndex < wordList.Count)
        {
            return wordList[wordIndex];
        }
        else
        {
            Debug.LogWarning("Invalid word index: " + wordIndex);
            return null;
        }
    }
}
