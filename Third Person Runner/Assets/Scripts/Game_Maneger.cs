using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Game_Maneger : MonoBehaviour
{
    public TextMeshProUGUI percent;
    public TextMeshProUGUI rank;
    public TextMeshProUGUI countdown;


    public void Update_Percent(int new_percent)
    {
        percent.text = new_percent.ToString() + "%";
    }

    public void Update_Rank(int new_rank)
    {
        rank.text = "#" + new_rank.ToString();
    }
    
}
