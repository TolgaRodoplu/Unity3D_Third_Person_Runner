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
    public Transform[] characters = new Transform[11];
    int player_index = 0;
    public GameObject End_Canvas;

    //Update the painted percent in UI
    public void Update_Percent(int new_percent)
    {
        percent.text = new_percent.ToString() + "%";
    }


    //Update the rank of the player in UI
    public void Update_Rank()
    {
        Bubble_Sort();
        rank.text = "#" + (player_index + 1).ToString();
    }

    //Bubble sort the players based on their values on z axis
    void Bubble_Sort()
    {
        for (int i = 0; i < characters.Length; i++)
        {
            for (int j = 0; j < characters.Length; j++)
            {

                //if the swaped character is player update the players index
                if (characters[i].position.z > characters[j].position.z)
                {
                    if (j == player_index)
                        player_index = i;

                    else if (i == player_index)
                        player_index = j;

                    Transform temp = characters[i];
                    characters[i] = characters[j];
                    characters[j] = temp;
                }

            }
        }
    }

    public void Activate_End_Canvas()
    {
        End_Canvas.SetActive(true);
    }
    

}
