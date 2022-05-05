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
        while(countdown_time > 0)
        {
            countdown_text.text = countdown_time.ToString();

            yield return new WaitForSeconds(1f);

            countdown_time--;
        }

        countdown_text.text = "GO!";

        GetComponent<Player_Controller>().enabled = true;

        yield return new WaitForSeconds(1f);

        countdown_text.gameObject.SetActive(false);

        this.enabled = false;

    }

}
