using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LootScoreManager : MonoBehaviour
{
    public static LootScoreManager instance;

    [SerializeField] TextMeshProUGUI scoreText;
    // [SerializeField] TextMeshProUGUI highScoreText;

    int score = 0;
    int miningCounter;
    // int highScore = 0;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        miningCounter = 0;
        scoreText.text = score.ToString();
        // highScoreText.text = highScore.ToString();
    }
        
    public void LootDrop()
    {
        miningCounter++;
        Debug.Log(miningCounter);

        int dropRate = Random.Range(1, 10); 

        if (dropRate % 3 == 0)
        {
            score += 100;
            Debug.Log(score);

            scoreText.text = score.ToString();
        }
        else
        {
            return;
        }
    }
}
