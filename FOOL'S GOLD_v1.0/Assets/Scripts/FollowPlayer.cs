using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerRb;
    [SerializeField] RectTransform canvas;
    [SerializeField] RectTransform infobox;
    //[SerializeField] float distance = 10f;

    void Update()
    {
        float playerPosX = playerRb.transform.position.x; //add offset as needed here
        float playerPosY = (playerRb.transform.position.y - 1.75f); //add offset as needed here
        float playerPosZ = playerRb.transform.position.z;

        Vector3 playerOffset = new Vector3(playerPosX, playerPosY, playerPosZ);

        Vector2 infoboxPoint = RectTransformUtility.WorldToScreenPoint(Camera.main, playerOffset);

        infobox.anchoredPosition = infoboxPoint - (canvas.sizeDelta / 2f);

        //Ray r = Camera.main.ScreenPointToRay(playerOffset);
        //Vector3 pos = r.GetPoint(distance);
        //transform.position = pos;
    }
}
