using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager singleton;
    public bool isRunning { get; private set; }
    public bool isEnded { get; private set; }

    [SerializeField] private float slowMotionFactor = 0.1f;

    private void Awake()
    {
        if(singleton == null)
        {
            singleton = this;
        }
        else if(singleton != this)
        {
            Destroy(gameObject);
        }

        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;
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
            Invoke("RestartGame", 2 * slowMotionFactor);
            Time.timeScale = slowMotionFactor;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }
    }

    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
    void Start()
    {
        StartGame();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
