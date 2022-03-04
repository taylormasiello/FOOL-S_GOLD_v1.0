using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    //[SerializeField] GameObject endMenu;
    //[SerializeField] Texture2D menuCursor;

    //public static bool gameOver = false;

    // when game timer reaches zero
    //public void GameOver()
    //{
    //    gameOver = true;
    //    endMenu.SetActive(true);
    //    Cursor.SetCursor(menuCursor, Vector2.zero, CursorMode.Auto);
    //}

    public void TitleMenu()
    {
        SceneManager.LoadScene(0);
    }

    //void Start()
    //{
    //    endMenu.SetActive(false);
    //    gameOver = false;
    //}

    // PH LOGIC; remove after GameOver() active and linked to GameTimer()
    //void Update()
    //{
    //    if (endMenu.activeSelf == true)
    //    {
    //        Cursor.SetCursor(menuCursor, Vector2.zero, CursorMode.Auto);
    //    }
    //}
}
