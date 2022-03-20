using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBtnAudio : MonoBehaviour
{
    public void PlayMenuBtnClick()
    {
        FindObjectOfType<AudioManager>().PlaySound("MenuClick");
    }

    public void EscApp()
    {
        if (Input.GetKeyDown(KeyCode.Backslash))
        {
            Application.Quit();
        }
    }

    void Update()
    {
        EscApp();        
    }
}
