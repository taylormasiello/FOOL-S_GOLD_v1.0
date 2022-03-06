using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerRb;
    public float distance = 10f;

    void Update()
    {
        float playerPosX = playerRb.transform.position.x; //add offset as needed here
        float playerPosY = playerRb.transform.position.y; //add offset as needed here
        float playerPosZ = playerRb.transform.position.z;

        Vector3 playerOffset = new Vector3(playerPosX, playerPosY, playerPosZ);

        Ray r = Camera.main.ScreenPointToRay(playerOffset);
        Vector3 pos = r.GetPoint(distance);
        transform.position = pos;
    }
}
