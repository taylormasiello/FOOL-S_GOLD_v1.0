using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mining : MonoBehaviour
{

    [SerializeField] GameObject miningInfoBox;
    [SerializeField] GameObject realGoldBox;
    [SerializeField] GameObject foolsGoldBox;


    bool isNowMining;
    public bool isLootDrop;

    void Start()
    {
        bool isLootDrop = false;
    }

    void Update()
    {
        MiningAction();
    }

    void MiningAction()
    {
        isNowMining = GameObject.Find("Kenny Goldinski (Player)").GetComponent<ToMine>().isMining;




        //if (isNowMining)
        //{
        //    miningTimer.value = time;
        //    //DELETE CELL on end; player input freeze/unfreeze on start/end of miningAction

        //    if (miningTimer.maxValue <= miningTimer.minValue)
        //    {
        //        isNowMining = false;
        //        miningInfoBox.SetActive(false);
        //        //DELETE CELL on end; player input freeze/unfreeze on start/end of miningAction

        //        bool isLootDrop = true;
        //        LootDrop(isLootDrop);

        //    }
        //}
    }

    void LootDrop(bool loot)
    {
        float timeDropShown = 3.0f;
        int dropRate = Random.Range(1, 9);

        if(isLootDrop)
        {
            timeDropShown -= Time.time;
            if (dropRate % 3 == 0)
            {
                realGoldBox.SetActive(true);
                //increment score
            }
            else
            {
                foolsGoldBox.SetActive(true);
            }
        }

        if(timeDropShown <= 0)
        {
            isLootDrop = false;
            realGoldBox.SetActive(false);
            foolsGoldBox.SetActive(false);
            //DELETE CELL on end; player input freeze/unfreeze on start/end of miningAction
        }


    }
}
