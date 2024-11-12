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


    public string GetLatestWord()
    {
        if (wordList != null && wordList.Count > 0)
        {
            return wordList[wordList.Count - 1]; 
        }
        return null;

    }

    public List<string> GetWordList() {
        return wordList;
    }
}
