using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceController : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    private List<string> previousWordList = new List<string>();
    private RewardCaption rewardCaption;

    void Start()
    {
        UpdateKeywordRecognizer();
        rewardCaption = GetComponent<RewardCaption>();
    }

    void Update()
    {
        // Continuously check for updates to the word list
        var currentWordList = WordCardsManager.Instance.GetWordList();

        // Check if the word list has changed
        if (!currentWordList.SequenceEqual(previousWordList))
        {
            Debug.Log("Word list has changed, updating KeywordRecognizer...");
            UpdateKeywordRecognizer();
        }
    }

    private void UpdateKeywordRecognizer()
    {
        // Stop the existing keyword recognizer if it's running
        if (keywordRecognizer != null && keywordRecognizer.IsRunning)
        {
            keywordRecognizer.Stop();
            keywordRecognizer.OnPhraseRecognized -= RecognizedSpeech;
            keywordRecognizer.Dispose();
        }

        // Get the updated word list
        var newWordList = WordCardsManager.Instance.GetWordList().ToArray();
        previousWordList = WordCardsManager.Instance.GetWordList().ToList();

        // Initialize a new keyword recognizer with the updated word list
        if (newWordList.Length > 0)
        {
            keywordRecognizer = new KeywordRecognizer(newWordList);
            keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
            keywordRecognizer.Start();
            Debug.Log("KeywordRecognizer updated with new words.");
        }
    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log("Recognized: " + speech.text);

        // Check if the recognized word matches any word from GetWordList
        if (WordCardsManager.Instance.GetWordList().Contains(speech.text))
        {
            rewardCaption.ShowRewardCaption();
            Debug.Log("Word Matched: " + speech.text);
            
        }
        else
        {
            Debug.Log("No match found for: " + speech.text);
        }
    }

    public void ActivateMicrophone()
    {
        if (keywordRecognizer != null && !keywordRecognizer.IsRunning)
        {
            keywordRecognizer.Start();
            Debug.Log("Microphone activated.");
        }
    }

    public void DeactivateMicrophone()
    {
        if (keywordRecognizer != null && keywordRecognizer.IsRunning)
        {
            keywordRecognizer.Stop();
            Debug.Log("Microphone deactivated.");
        }
    }

    private void OnDestroy()
    {
        if (keywordRecognizer != null)
        {
            keywordRecognizer.OnPhraseRecognized -= RecognizedSpeech;
            keywordRecognizer.Dispose();
        }
    }
}
