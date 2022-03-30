using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject gameMode;
    public GameObject startButton;
    public Timer timer;

    public bool isGameRunning;

    public string returnedElementName;
    public string returnedElementNumber;
    public string returnedElementShortForm;


    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        timer = GetComponent<Timer>();
    }


    public void StartGame()
    {
        isGameRunning = true;
        startButton.SetActive(false);
        gameMode.SetActive(true);
        timer.StartScoreCount();
    }

    public void EndGame()
    {
        isGameRunning = false;
        gameMode.SetActive(false);
        startButton.SetActive(true);
        timer.StopTimer();
    }

    public void AddScore()
    {
        timer.score = timer.score + 100;
    }

    public void SubtractScore()
    {
        timer.score = timer.score - 50;
    }

}
