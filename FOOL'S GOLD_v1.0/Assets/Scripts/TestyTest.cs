using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestyTest : MonoBehaviour
{
    [SerializeField] GameObject miningInfoBox;
    [SerializeField] Slider miningProgress;

    //void Start()
    //{

    //}

    void Update()
    {
        Mining();
    }

    void Mining()
    {
        if (miningInfoBox.activeSelf)
        {
            Vector3 boxPos = (miningInfoBox.transform.position);

            miningProgress.minValue = 0f;
            miningProgress.maxValue = 5f;
            miningProgress.value = 0f;
            //miningProgress.value -= Time.time;

            if (miningProgress.value < miningProgress.maxValue)
            {
                miningProgress.value += Time.time;
            }
            else if (miningProgress.value >= miningProgress.maxValue)
            {
                miningInfoBox.SetActive(false);
                // miningProgress.value = miningProgress.maxValue;
            }

            //if (miningProgress.value <= 0.01f)
            //{
            //    miningInfoBox.SetActive(false);
            //    //Instantiate(miningInfoBox, miningInfoBox.transform);
            //}
        }
    }
}
