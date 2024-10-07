using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceController : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    [SerializeField] private Dictionary<string,Action> actions = new Dictionary<string,Action>();
    [SerializeField] private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        /*actions.Add("up", Up);
        actions.Add("down", Down);*/

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;

        keywordRecognizer.Start();

    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

/*    public void GenerateWord() {
        actions.
    }
*/
}
