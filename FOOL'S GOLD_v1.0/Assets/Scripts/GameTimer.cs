using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [SerializeField] GameObject endMenu;
    [SerializeField] float timeStart = 5f;

    public float timeLeft;
    public bool gameOver;
    Image gameTimer;

    void Awake()
    {
        gameTimer = GameObject.Find("Timer").GetComponent<Image>();
    }

    void Start()
    {
        StartTimer();
    }

    void Update()
    {
        RunningTimer();

        if (timeLeft < 3 && timeLeft > 2.99)
        {
            FindObjectOfType<AudioManager>().PlaySound("TimeTicking");
        } else if (timeLeft <= 0.1)
        {
            FindObjectOfType<AudioManager>().StopSound("TimeTicking");
        } 
        
        if (timeLeft <= 0.1 && timeLeft >= 0.09)
        {
            FindObjectOfType<AudioManager>().PlaySound("EndLevel");
        }
    }

    public void StartTimer()
    {
        timeLeft = timeStart;
        gameOver = false;
        endMenu.SetActive(false);
    }


    public void RunningTimer()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            gameTimer.fillAmount = 1 - (timeLeft / timeStart);
        }
        else
        {
            Time.timeScale = 0;
            gameOver = true;
            endMenu.SetActive(true);
        }
    }
}