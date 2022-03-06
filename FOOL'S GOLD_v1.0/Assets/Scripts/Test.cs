using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    [SerializeField] GameObject miningInfoBox;
    //float miningTime;

    int timerSeconds;

    void Start()
    {
        InvokeRepeating("MiningTimer", 1, 2);
    }

    void MiningTimer()
    {
        timerSeconds = 3;
        timerSeconds -= (int)Time.time;

        if (timerSeconds <= 0.01)
        {
            miningInfoBox.SetActive(false);
        }
    }

    //void Start()
    //{
    //    //miningTime = Random.Range(1.0f, 3.0f);
    //    // (Random.Range(2.0f, 5.0f)), (Random.Range(2.0f, 5.0f))
    //    InvokeRepeating("EndMiningAction", 2.5f, 2.5f);
    //}

    //void EndMiningAction()
    //{
    //    miningInfoBox.SetActive(false);
    //}


}
