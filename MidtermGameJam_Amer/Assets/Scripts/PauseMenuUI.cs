using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenuUI : MonoBehaviour
{
    public GameObject pauseMenu;

    public void Pause()
    {
        if(Time.timeScale == 1f)
        {
            Time.timeScale = 0f;
        }
        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }
        pauseMenu.SetActive(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }


    public void Quit()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
