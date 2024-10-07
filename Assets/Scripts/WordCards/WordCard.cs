using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WordCard", menuName = "SeriousGames/Make new WordCard", order = 0)]
public class WordCard : ScriptableObject {


    [SerializeField] private string word;

    public string GetWord() {

        return word;
    }
}
