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
            miningProgress.value += 0.11f;
        }
        else if (miningProgress.value >= miningProgress.maxValue)
        {
            miningProgress.value = 0;
        }

    }
}
