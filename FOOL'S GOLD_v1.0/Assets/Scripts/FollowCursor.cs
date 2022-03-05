using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCursor : MonoBehaviour
{
    public float distance = 10f;

    void Update()
    {
        float cursorPosX = (Input.mousePosition.x + 75);
        float cursorPosY = (Input.mousePosition.y - 25);
        float cursorPosZ = (Input.mousePosition.z);

        Vector3 cursorOffset = new Vector3(cursorPosX, cursorPosY, cursorPosZ);

        Ray r = Camera.main.ScreenPointToRay(cursorOffset);
        Vector3 pos = r.GetPoint(distance);
        transform.position = pos;        
    }

}
