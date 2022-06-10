using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortPlayers : MonoBehaviour
{
    private Transform[] characters;
    private int playerIndex = 0;
    private bool isSorting = false;
    private void Start()
    {
        //Register to the appropriate event
        EventSystem.instance.runningStarted += StartSort;
        EventSystem.instance.runningStopped += EndSort;
    }

    private void StartSort()
    {
        InitilizeCharacters();
        isSorting = true;
    }

    private void Update()
    {
        if(isSorting)
        {
            SortAlgoritm();

            //Notify the EventSystem that Rank is Updated
            EventSystem.instance.UpdateRank((playerIndex));
        }
        
    }

    //Initilize the characters array
    private void InitilizeCharacters()
    {
        characters = new Transform[transform.childCount];

        for (int i = 0; i < characters.Length; i++)
            characters[i] = transform.GetChild(i);
    }

    //Sort the players based on their z value
    private void SortAlgoritm()
    {
        for (int i = 0; i < characters.Length; i++)
        {
            for (int j = 0; j < characters.Length; j++)
            {

                //if the swaped character is player update the players index
                if (characters[i].position.z > characters[j].position.z)
                {
                    if (j == playerIndex)
                        playerIndex = i;

                    else if (i == playerIndex)
                        playerIndex = j;

                    Transform temp = characters[i];
                    characters[i] = characters[j];
                    characters[j] = temp;
                }

            }
        }
    }

    private void EndSort()
    {
        EventSystem.instance.runningStarted -= StartSort;
        EventSystem.instance.runningStopped -= EndSort;
        isSorting = false;
        this.enabled = false;
    }
}
