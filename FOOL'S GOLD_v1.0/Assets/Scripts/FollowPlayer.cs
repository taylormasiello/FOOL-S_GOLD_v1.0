//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerRb;
    [SerializeField] RectTransform canvas;
    [SerializeField] RectTransform infoBox;

    void Update()
    {
        float playerPosX = playerRb.transform.position.x + 5f;
        float playerPosY = (playerRb.transform.position.y + 0.75f);
        float playerPosZ = playerRb.transform.position.z;

        Vector3 playerOffset = new Vector3(playerPosX, playerPosY, playerPosZ);

        Vector2 infoBoxPoint = RectTransformUtility.WorldToScreenPoint(Camera.main, playerOffset);

        infoBox.anchoredPosition = infoBoxPoint - (canvas.sizeDelta / 2f);
    }
}
