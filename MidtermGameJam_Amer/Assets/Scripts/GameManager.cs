using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager sinleton;
    public bool isRunning { get; private set; }
    public bool isEnded { get; private set; }

    private void Awake()
    {
        if(sinleton == null)
        {
            sinleton = this;
        }
        else if(sinleton != this)
        {
            Destroy(gameObject);
        }
    }

    public void StartGame()
    {
        isRunning = true;
        Debug.Log("Game Running");
    }

    public void EndGame(bool win)
    {
        isEnded = true;
        Debug.Log("Game Over");

        if(!win)
        {
            Invoke("RestartGame", 0);
        }
    }

    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
