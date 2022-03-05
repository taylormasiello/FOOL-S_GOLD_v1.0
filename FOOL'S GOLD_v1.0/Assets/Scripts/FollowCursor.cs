using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCursor : MonoBehaviour
{
    public float distance = 10f;

    void Update()
    {
        Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 pos = r.GetPoint(distance);
        transform.position = pos;
    }

}
