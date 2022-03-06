using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mining : MonoBehaviour
{
    [SerializeField] Slider miningTimer;
    [SerializeField] GameObject miningInfoBox;

    [SerializeField] GameObject realGoldBox;
    [SerializeField] GameObject foolsGoldBox;

    float timerTime;
    bool isNowMining;

    //rand int for realVSfake drop logic between 1-9

    //DELETE CELL on end; player input freeze/unfreeze on start/end of miningAction
    
    void Start()
    {
        miningTimer.minValue = 0;
        miningTimer.maxValue = Random.Range(0.5f, 3.0f); ;
        miningTimer.value = timerTime;
    }

    void Update()
    {
        isNowMining = GameObject.Find("Kenny Goldinski (Player)").GetComponent<ToMine>().isMining;
        float time = timerTime - Time.time;

        if (isNowMining)
        {
            miningTimer.value = time;
            
            if(miningTimer.maxValue <= miningTimer.minValue)
            {
                isNowMining = false;
                miningInfoBox.SetActive(false);

                //if( randInt 1-9 % 3 = 0)
                //{
                //    realGoldBox.SetActive(true);
                        //increment score
                        //setActive False after 3 sec delay
                //}
                //else
                //{
                //    foolsGoldBox.SetActive(true);
                        //setActive False after 3 sec delay
                //}

            }
        }
    }
}
