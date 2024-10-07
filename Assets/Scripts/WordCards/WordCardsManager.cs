using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WordCardsManager : MonoBehaviour
{
    public static WordCardsManager Instance { get; private set; }

    private List<string> wordList;
    private void Awake()
    {
        wordList = new List<string>();
    }

    private void Start()
    {
        Instance = this;

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

    public List<string> GetWordList() {
        return wordList;
    }
}
