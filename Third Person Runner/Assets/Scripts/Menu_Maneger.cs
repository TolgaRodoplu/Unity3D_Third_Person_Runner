using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Maneger : MonoBehaviour
{
    public void Star_Restart_Game()
    {
        SceneManager.LoadScene("Main");
    }
    public void Return_to_Menu()
    {
        SceneManager.LoadScene("Menu");
    }
    
}
