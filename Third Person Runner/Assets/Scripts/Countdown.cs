using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    
    public int countdown_time = 3;
    public TextMeshProUGUI countdown_text;

    private void Start()
    {
        StartCoroutine(Start_Countdown());
    }

    IEnumerator Start_Countdown()
    {
        //Play the countdown audio
        FindObjectOfType<Audio_Maneger>().Play("Countdown");


        while(countdown_time > 0)
        {
            //Write the time in UI
            countdown_text.text = countdown_time.ToString();

            //Wait for 1 second
            yield return new WaitForSeconds(1f);

            //decrement the timer
            countdown_time--;
        }

        //When timer hit zero write GO! in UI
        countdown_text.text = "GO!";

        //Start Game
        GetComponent<Player_Controller>().enabled = true;

        //Wait for 1 second
        yield return new WaitForSeconds(1f);

        //disable the countdown in UI
        countdown_text.gameObject.SetActive(false);

        //Play and loop the background music
        FindObjectOfType<AudioSource>().loop = true;

        FindObjectOfType<Audio_Maneger>().Play("Background");

        //disable this script
        this.enabled = false;

    }

}
