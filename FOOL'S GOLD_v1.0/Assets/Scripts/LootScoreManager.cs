using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LootScoreManager : MonoBehaviour
{
    public static LootScoreManager instance;

    // [SerializeField] GameObject miningInfoBox;
    [SerializeField] GameObject realGoldBox;
    [SerializeField] GameObject foolsGoldBox;
    
    [SerializeField] Slider miningSlider;
    [SerializeField] AudioManager audioManager;
    [SerializeField] TextMeshProUGUI scoreText;

    public static int highScore = 0;
    int score = 0;
    float timeShown;

    void Awake()
    {
        instance = this;
        highScore = PlayerPrefs.GetInt("highScore", 0);
    }

    void Start()
    {

        InvokeRepeating("timeBoxShown", 0.5f, 0.5f);       
        scoreText.text = score.ToString();
    }

    void Update()
    {
        highScore = PlayerPrefs.GetInt("highScore", 0);
    }

    public void LootDrop()
    {
        int dropRate = Random.Range(1, 4); 

        if (dropRate != 1)
        {
            timeShown = 1.5f;

            realGoldBox.SetActive(true);
            foolsGoldBox.SetActive(false);

            score += 100;
            

            if (highScore <= score)
            {
                PlayerPrefs.SetInt("highScore", score);
            }          
        }
        else
        {
            timeShown = 1.5f;
            
            foolsGoldBox.SetActive(true);
            realGoldBox.SetActive(false);
        }        
    }

    void timeBoxShown()
    {  
        if (realGoldBox.activeInHierarchy && !foolsGoldBox.activeInHierarchy)
        {
            timeShown -= 0.5f;
            scoreText.text = score.ToString();
            

            if (timeShown <= 0.01f)
            {
                realGoldBox.SetActive(false);

            }
            else if (timeShown <= 0.65f)
            {
                scoreText.text = score.ToString();
                audioManager.PlaySound("RealGoldDrop");
            }
        }
        else if (foolsGoldBox.activeInHierarchy && !realGoldBox.activeInHierarchy)
        {
            timeShown -= 0.5f;
            

            if (timeShown <= 0.01f)
            {
                foolsGoldBox.SetActive(false);
            }
            else if (timeShown <= 0.65f)
            {
                audioManager.PlaySound("FoolGoldDrop");
            }
        }
        
    }
}
