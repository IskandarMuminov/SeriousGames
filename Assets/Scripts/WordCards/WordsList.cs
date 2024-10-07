using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordsList : MonoBehaviour
{
    private List<string> words;

    public WordsList()
    {
        words = new List<string> {
        "apple",
        "bread"
        };
    }

    public void AddWord(string word)
    {
        if (word.Length == 5 && words.Count < 100)
        {
            words.Add(word);
        }
        else
        {
            throw new ArgumentException("Word must be 5 letters long and the list must not exceed 100 words.");
        }
    }

    public string GetRandomWord(int index)
    {
        if (index >= 0 && index < words.Count)
        {
            return words[index];
        }
        else
        {
            throw new IndexOutOfRangeException("Index out of range.");
        }
    }

    public List<string> GetAllWords()
    {
        return new List<string>(words);
    }

    public int GetWordCount()
    {
        return words.Count;
    }
}

