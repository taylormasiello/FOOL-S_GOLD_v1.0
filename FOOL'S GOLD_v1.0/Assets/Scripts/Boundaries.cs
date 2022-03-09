//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Boundaries : MonoBehaviour
//{
//    [SerializeField] Camera MainCamera;

//    Vector2 screenBounds;
//    float infoBoxWidth;
//    float infoBoxHeight;

//    void Start()
//    {
//        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));

//        infoBoxWidth = transform.GetComponent<RectTransform>().sizeDelta.x / 2 ;
//        infoBoxHeight = transform.GetComponent<RectTransform>().sizeDelta.y / 2;
//    }

//    void LateUpdate()
//    {
//        Vector3 viewPos = transform.position;
//        viewPos.x = Mathf.Clamp(viewPos.x, (screenBounds.x * -1 + infoBoxWidth), (screenBounds.x - infoBoxWidth));
//        viewPos.y = Mathf.Clamp(viewPos.y, (screenBounds.y * -1 + infoBoxHeight), (screenBounds.y - infoBoxHeight));
//        transform.position = viewPos;
//    }
//}
