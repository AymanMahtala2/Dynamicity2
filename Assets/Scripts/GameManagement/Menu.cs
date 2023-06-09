using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Lorin Outskirts");
    }
    public void LoadGame()
    {
        if(PlayerPrefs.GetInt("hasSavedGame") == 1)
        {
            SceneManager.LoadScene("GeneralStore");
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
