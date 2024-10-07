using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WordCardCover : MonoBehaviour
{
    [SerializeField] private WordCard wordCard;
    private TextMeshProUGUI wordDisplayText;


    // Start is called before the first frame update
    void Start()
    {
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
        WordCardsManager.Instance.GetWordList().Add(word);
    }
}
