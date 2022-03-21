//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Texture2D menuCursor;
    [SerializeField] AudioManager audioManager;
    [SerializeField] GameObject mainMenuUI;

    public void PlayGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void Start()
    {
        Time.timeScale = 0;
    }

    void Update()
    {
        if (mainMenuUI.activeInHierarchy == true)
        {
            Cursor.SetCursor(menuCursor, Vector2.zero, CursorMode.Auto);
        }
    }
}
