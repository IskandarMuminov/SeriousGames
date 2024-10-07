using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordDisplayer : MonoBehaviour, IInteractible
{
    [SerializeField] private GameObject wordCanvas;
    private TextBox textBox;

    private void Start()
    {
        textBox = GetComponentInChildren<TextBox>();
    }
    public void Interact()
    {
        if (wordCanvas != null)
        {
            wordCanvas.SetActive(true);
            textBox.StartText();
        }
    }
}
