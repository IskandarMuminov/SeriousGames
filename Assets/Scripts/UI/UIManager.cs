using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject wordCardSelectionUI;

    [SerializeField] private bool isSelectingAWordCard;

    public void CardSelectionMenu() {
            if (isSelectingAWordCard)
            {
                Resume();
            }
            else
            {
                Pause();
            }
    }

    public void Pause() {
        wordCardSelectionUI.SetActive(true);
        Time.timeScale = 0;
        isSelectingAWordCard = true;
    }
    public void Resume() {
        wordCardSelectionUI.SetActive(false);
        Time.timeScale = 1;
        isSelectingAWordCard = false;
    }

}
