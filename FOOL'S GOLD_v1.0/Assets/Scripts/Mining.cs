using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mining : MonoBehaviour
{

    [SerializeField] GameObject miningInfoBox;
    [SerializeField] GameObject realGoldBox;
    [SerializeField] GameObject foolsGoldBox;


    //bool isNowMining;
    public bool isLootDrop;
    float miningTime;

    void Start()
    {
        //isNowMining = false;

        //InvokeRepeating("TimePassing", 1.0f, 1.0f);
        isLootDrop = false;
    }

    void Update()
    {
        MiningAction();
    }

    //void TimePassing()
    //{
    //    time -= Time.deltaTime;
    //}

    void MiningAction()
    {
        miningTime = Random.Range(5.0f, 10.0f);
        
        if (miningInfoBox.activeSelf)
        {
            float time = miningTime - Time.time;
            //player input freeze on start of miningAction
            if (time <= 0.01f)
            {
                //isNowMining = false;
                miningInfoBox.SetActive(false);
                Debug.Log("finished mining");
                //DELETE CELL on end
                //player input unfreeze on end of miningAction

                isLootDrop = true;
                //LootDrop(isLootDrop);
                
            }            
        }
    }

    //void LootDrop(bool loot)
    //{
    //    float timeDropShown = 3.0f;
    //    int dropRate = Random.Range(1, 9);

    //    if(isLootDrop)
    //    {
    //        timeDropShown -= Time.time;
    //        if (dropRate % 3 == 0)
    //        {
    //            realGoldBox.SetActive(true);
    //            //increment score
    //        }
    //        else
    //        {
    //            foolsGoldBox.SetActive(true);
    //        }
    //    }

    //    if(timeDropShown <= 0)
    //    {
    //        isLootDrop = false;
    //        realGoldBox.SetActive(false);
    //        foolsGoldBox.SetActive(false);
    //    }
    //}
}
