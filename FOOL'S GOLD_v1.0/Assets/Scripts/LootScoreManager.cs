using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LootScoreManager : MonoBehaviour
{
    public static LootScoreManager instance;

    [SerializeField] GameObject miningInfoBox;
    [SerializeField] GameObject realGoldBox;
    [SerializeField] GameObject foolsGoldBox;
    [SerializeField] Slider miningSlider;

    [SerializeField] TextMeshProUGUI scoreText;
    // [SerializeField] TextMeshProUGUI highScoreText;

    int score = 0;
    int miningCounter;
    // int highScore = 0;
    float timeShown;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        InvokeRepeating("timeBoxShown", 0.5f, 0.5f);
        miningCounter = 0;
        scoreText.text = score.ToString();
        // highScoreText.text = highScore.ToString();
    }
        
    public void LootDrop()
    {
        miningCounter++;

        int dropRate = Random.Range(1, 3); 

        if (dropRate % 2 == 0)
        {
            timeShown = 1.5f;
            //delete cell of rock

            realGoldBox.SetActive(true);
            foolsGoldBox.SetActive(false);

            score += 100;

        }
        else
        {
            timeShown = 1.5f;
            //delete cell of rock

            foolsGoldBox.SetActive(true);
            realGoldBox.SetActive(false);
        }
        
    }

    void timeBoxShown()
    {  
        if (realGoldBox.activeInHierarchy && !foolsGoldBox.activeInHierarchy)
        {
            timeShown -= 0.5f;
                
            if (timeShown <= 0.01f)
            {
                realGoldBox.SetActive(false);
            }
            else if (timeShown <= 0.65f)
            {
                scoreText.text = score.ToString();
            }
        }
        else if (foolsGoldBox.activeInHierarchy && !realGoldBox.activeInHierarchy)
        {
            timeShown -= 0.5f;

            if (timeShown <= 0.01f)
            {
                foolsGoldBox.SetActive(false);
            }
        }
        
    }
}
