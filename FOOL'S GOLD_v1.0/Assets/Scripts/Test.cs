using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    [SerializeField] GameObject miningInfoBox;

    void Start()
    {
        float miningTime = Random.Range(2.0f, 3.0f);
        InvokeRepeating("EndMiningAction", miningTime, 3f);
    }

    void EndMiningAction()
    {
        miningInfoBox.SetActive(false);
    }
}
