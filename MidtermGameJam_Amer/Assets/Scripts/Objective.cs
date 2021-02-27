using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerController ball = other.GetComponent<PlayerController>();

        if (!ball || GameManager.singleton.IsEnded)
            return;
        Debug.Log("Finished Game");
        GameManager.singleton.EndGame(true);
    }
}
