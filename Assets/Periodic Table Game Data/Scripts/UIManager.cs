using HoloToolkit.MRDL.PeriodicTable;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public List<string> elementList = new List<string>();

    public string question;
    public int questionNumber;

    public TextMeshPro questionUI;

    public TextMeshPro resultUIText;
    public GameObject resultUI;

    public TextMeshPro highScoreUI;
    public int highScore;

    public PeriodicTableLoader periodicTableLoader;


    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        timer = GetComponent<Timer>();
    }

    public void Start()
    {
        SetHighScore();
    }

    public void SetHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
        highScoreUI.text = highScore.ToString();
    }

    public void StartGame()
    {
        isGameRunning = true;
        startButton.SetActive(false);
        gameMode.SetActive(true);
        
        timer.StartScoreCount();
        GetQuestion();
        SetHighScore();
    }

    public void EndGame()
    {
        isGameRunning = false;
        gameMode.SetActive(false);
        startButton.SetActive(true);
        timer.StopTimer();
        if(timer.score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", timer.score);
            highScoreUI.text = timer.score.ToString();
        }
        elementList.Clear();
        periodicTableLoader.InitializeData();

        GameObject[] tempWrongObjects = GameObject.FindGameObjectsWithTag("wrong");

        foreach (GameObject tempWrongObject in tempWrongObjects)
        {
            tempWrongObject.SetActive(false);
        }

        GameObject[] tempCorrectObjects = GameObject.FindGameObjectsWithTag("correct");

        foreach (GameObject tempCorrectObject in tempCorrectObjects)
        {
            tempCorrectObject.SetActive(false);
        }
    }

    public void GetQuestion()
    {
        questionNumber = Random.Range(0, elementList.Count);
        question = elementList[questionNumber];
        questionUI.text = question;
        elementList.RemoveAt(questionNumber);        
    }

    public void PopUpResult()
    {
        resultUI.SetActive(true);
        StartCoroutine("PopUpDelay");
    }

    IEnumerator PopUpDelay()
    {
        yield return new WaitForSeconds(1f);
        resultUI.SetActive(false);
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
