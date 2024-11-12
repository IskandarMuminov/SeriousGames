using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RewardCaption : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI rewardCaption;

    private void Start()
    {
        rewardCaption.gameObject.SetActive(false);
    }

    public void ShowRewardCaption()
    {
        StartCoroutine(DisplayCaptionForSeconds(2f));
    }

    private IEnumerator DisplayCaptionForSeconds(float seconds)
    {
        rewardCaption.gameObject.SetActive(true);
        yield return new WaitForSeconds(seconds);
        rewardCaption.gameObject.SetActive(false);
    }

}
