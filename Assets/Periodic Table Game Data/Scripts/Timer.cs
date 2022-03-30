using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public int score = 0;

    public TextMeshPro scoreUI;

    public void StartScoreCount()
    {
        score = 0;
        InvokeRepeating("RunTimer", 0f, 1f);
    }

    public void RunTimer()
    {
        if (UIManager.Instance.isGameRunning)
        {
            score -= 1;
            scoreUI.text = score.ToString();
        }
    }

    public void StopTimer()
    {
        CancelInvoke("RunTimer");
    }
}
