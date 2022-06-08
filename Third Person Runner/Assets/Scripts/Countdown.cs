using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    public int countdownTime = 3;

    private void Start()
    {
        //Register to the gameStarted event
        EventSystem.instance.gameStarted += CountdownStart;
    }

    void CountdownStart()
    {
        StartCoroutine(CountdownTimer());
    }

    IEnumerator CountdownTimer()
    {
        //Play the countdown audio
        FindObjectOfType<AudioManeger>().Play("Countdown");


        while(countdownTime > 0)
        {
            //Write the time in UI
            EventSystem.instance.UpdateCountdown(countdownTime.ToString());

            //Wait for 1 second
            yield return new WaitForSeconds(1f);

            //decrement the timer
            countdownTime--;
        }

        //Write the time in UI
        EventSystem.instance.UpdateCountdown("GO!");

        EventSystem.instance.StartRunning();

        //Wait for 1 second
        yield return new WaitForSeconds(1f);

        //Write the time in UI
        EventSystem.instance.UpdateCountdown("");

        //Play and loop the background music
        FindObjectOfType<AudioSource>().loop = true;

        FindObjectOfType<AudioManeger>().Play("Background");

        //disable this script
        this.enabled = false;

    }

}
