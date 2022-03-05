using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    [SerializeField] Texture2D pauseCursor;
    [SerializeField] Texture2D searchingCursor;
    [SerializeField] GameObject pauseMenuUI;

    void Update()
    {
        EscKey();
    }

    public void EscKey()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;
        Time.timeScale = 1f;

        Cursor.SetCursor(searchingCursor, Vector2.zero, CursorMode.Auto);
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        GameIsPaused = true;
        Time.timeScale = 0f;

        Cursor.SetCursor(pauseCursor, Vector2.zero, CursorMode.Auto);           
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene(0);
    }
}