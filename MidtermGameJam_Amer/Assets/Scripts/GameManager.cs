using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager singleton;
    public bool IsRunning { get; private set; }
    public bool IsEnded { get; private set; }

    [SerializeField] private float slowMotionFactor = 0.1f;
    [SerializeField] private Transform StartlineTransform;
    [SerializeField] private Transform FinishlineTransform;
    [SerializeField] private PlayerController ball;

    public float TotalDistance { get; private set; }
    public float DistanceRemaining { get; private set; }
 

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
        IsRunning = true;
        Debug.Log("Game Running");
    }

    public void EndGame(bool win)
    {
        IsEnded = true;
        Debug.Log("Game Over");

        if(!win)
        {
            Invoke("RestartGame", 2 * slowMotionFactor);
            Time.timeScale = slowMotionFactor;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }
        else
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
   private void Start()
    {
        StartGame();

        TotalDistance = (FinishlineTransform.position.z - StartlineTransform.position.z);

    }
    // Update is called once per frame
    void Update()
    {
        DistanceRemaining = Vector3.Distance(ball.transform.position, FinishlineTransform.position);

        if (DistanceRemaining > TotalDistance)
            DistanceRemaining = TotalDistance;

        if (ball.transform.position.z > FinishlineTransform.transform.position.z)
            DistanceRemaining = 0;
        Debug.Log("Remaining Distance is " + DistanceRemaining + " Entire Distance is " + TotalDistance);
    }
}
