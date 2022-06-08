using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UISystem : MonoBehaviour
{
    public TextMeshProUGUI rankText, percentText, countdownText;
    public GameObject endUI;

    private void Start()
    {
        EventSystem.instance.rankUpdated += RankUpdate;
        EventSystem.instance.percentUpdated += PercentUpdate;
        EventSystem.instance.countdownUpdated += CountdownUpdate;
        EventSystem.instance.gameEnded += ActivateEndUI;
    }

    //Update the rank of the player in UI
    private void RankUpdate(object sender, int newRank)
    {
        rankText.text = "#" + (newRank + 1).ToString();
    }

    //Update the painted percent in UI
    private void PercentUpdate(object sender, int newPercent)
    {
        percentText.text = newPercent.ToString() + "%";
    }
    private void CountdownUpdate(object sender, string countdown)
    {
        countdownText.text = countdown;
    }

    private void ActivateEndUI()
    {
        EventSystem.instance.rankUpdated -= RankUpdate;
        EventSystem.instance.percentUpdated -= PercentUpdate;
        EventSystem.instance.countdownUpdated -= CountdownUpdate;
        EventSystem.instance.gameEnded -= ActivateEndUI;
        endUI.SetActive(true);
    }
}
