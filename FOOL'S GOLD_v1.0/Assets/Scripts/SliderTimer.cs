using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderTimer : MonoBehaviour
{
    [SerializeField] Slider miningProgress;
    //[SerializeField] GameObject miningInfoBox;
    //[SerializeField] GameObject realGoldBox;

    //float progress;
    
    //float mineTime;

    //bool isNowMining;
    //bool isLootDrop;

    void Start()
    {
        InvokeRepeating("ProgressChange", 1.0f, 1.0f);
        miningProgress.value = 0;
    }

    void ProgressChange()
    {
        if (miningProgress.value < miningProgress.maxValue)
        {
            miningProgress.value += 1;
        }
        else if (miningProgress.value >= miningProgress.maxValue)
        {
            miningProgress.value = 0;
        }

    }

    //isNowMining = GameObject.Find("Kenny Goldinski (Player)").GetComponent<ToMine>().isMining;

    //miningTimer.maxValue = Random.Range(1.0f, 3.0f);
    //miningTimer.value = timeLeft;

    //isLootDrop = false;



    //mineTime = Random.Range(5.0f, 10.0f);

    //if (isNowMining)
    //{

    //}



    void Update()
    {
        //timeLeft = miningTimer.maxValue - Time.time;

        //if (isNowMining)
        //{
        //    
        //    Slider();
        //    //if (timeLeft <= miningTimer.minValue)
        //    //{
        //    //    isNowMining = false;
        //    //    miningInfoBox.SetActive(false);
        //        //DELETE CELL on end; player input freeze/unfreeze on start/end of miningAction

        //        //isLootDrop = true;
        //        //LootDrop(isLootDrop);
        //        //realGoldBox.SetActive(true);

        //    //}
        //}


    }



    //void Slider()
    //{



    //    if (timeLeft <= miningTimer.minValue)
    //    {
    //        isNowMining = false;
    //        miningInfoBox.SetActive(false);
    //    }
    //}
}
