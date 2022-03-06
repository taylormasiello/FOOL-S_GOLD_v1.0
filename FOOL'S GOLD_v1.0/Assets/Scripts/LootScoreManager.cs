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
        Debug.Log(miningCounter);

        int dropRate = Random.Range(1, 10); 
        //float timeBoxShown = 5f;

        if (dropRate % 3 == 0)
        {
            score += 100;
            Debug.Log(score);

            scoreText.text = score.ToString();

            timeShown = 2f;
            realGoldBox.SetActive(true);
            foolsGoldBox.SetActive(false);
            //timeBoxShown -= Time.time;

            //if(timeBoxShown <= 0.01)
            //{
            //    realGoldBox.SetActive(false);
            //}
        }
        else
        {
            timeShown = 2f;
            foolsGoldBox.SetActive(true);
            realGoldBox.SetActive(false);
            //timeBoxShown -= Time.time;
            //if (timeBoxShown <= 0.01)
            //{
            //    foolsGoldBox.SetActive(false);
            //}
        }
        
    }

    void timeBoxShown()
    {


        
        {
            if (realGoldBox.activeInHierarchy && !foolsGoldBox.activeInHierarchy)
            {
                timeShown -= 0.5f;
                
                if (timeShown <= 0.01f)
                {
                    realGoldBox.SetActive(false);
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
}
