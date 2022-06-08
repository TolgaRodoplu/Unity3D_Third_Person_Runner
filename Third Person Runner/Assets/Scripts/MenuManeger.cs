using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManeger : MonoBehaviour
{
    public void StartRestartGame()
    {
        SceneManager.LoadScene("Main");
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    
}
