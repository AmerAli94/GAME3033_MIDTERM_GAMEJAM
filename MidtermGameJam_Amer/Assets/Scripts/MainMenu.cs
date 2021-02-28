using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject creditMenu;

    public void Play()
    {

        SceneManager.LoadScene(1);
    }

    //public void Resume()
    //{
    //    if (Time.timeScale == 0f)
    //    {
    //        Time.timeScale = 1f;
    //    }
    //    pauseMenu.SetActive(false);
    //}
    public void Credits()
    {
        creditMenu.SetActive(true);
    }
    public void CreditsClose()
    {
        creditMenu.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
        creditMenu.SetActive(false);
    }
}
