using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderTimer : MonoBehaviour
{
    [SerializeField] Slider miningProgress;

    void Start()
    {
        InvokeRepeating("ProgressChange", 0.1f, 0.1f);
        miningProgress.value = 0;
    }

    void ProgressChange()
    {
        if (miningProgress.value < miningProgress.maxValue)
        {
            miningProgress.value += 0.07f;
        }
        else if (miningProgress.value >= miningProgress.maxValue)
        {
            miningProgress.value = 0;
        }

    }
}

//miningInfoBox.SetActive(true);

//bool active = miningInfoBox.activeInHierarchy;
//Debug.Log(active);

//if(active)
//{
//    if (miningProgress.value < miningProgress.maxValue)
//    {
//        miningProgress.value += Time.time;
//    }
//    //else if (miningProgress.value >= miningProgress.maxValue)
//    //{
//    //    miningInfoBox.SetActive(false);
//    //}
//}




//if (miningInfoBox.activeInHierarchy)
//{
//    miningProgress.value += Time.time;
//}

//if (miningProgress.value >= miningProgress.maxValue)
//{
//    miningInfoBox.SetActive(false);
//}