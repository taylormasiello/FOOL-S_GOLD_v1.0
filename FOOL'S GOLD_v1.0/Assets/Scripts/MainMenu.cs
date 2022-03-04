using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Texture2D menuCursor;
    //[SerializeField] Texture2D searchingCursor;

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        //Cursor.SetCursor(searchingCursor, Vector2.zero, CursorMode.Auto);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void Start()
    {
        Cursor.SetCursor(menuCursor, Vector2.zero, CursorMode.Auto);
    }
}
