using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameUI : MonoBehaviour
{
    [SerializeField] private Image progressBarFill;

    private float lastValue = 0;

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.singleton.IsRunning)
            return;

        float coveredDistance = (GameManager.singleton.TotalDistance - GameManager.singleton.DistanceRemaining);
        float value = coveredDistance / GameManager.singleton.TotalDistance;

        if (GameManager.singleton.gameObject && value < lastValue)
            return;

        progressBarFill.fillAmount = Mathf.Lerp(progressBarFill.fillAmount, value, 10 * Time.deltaTime);

        //Debug.Log(lastValue);
    }
}
