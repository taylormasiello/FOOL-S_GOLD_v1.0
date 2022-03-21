using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{    
    [SerializeField] GameObject pauseMenuUI;
    public static bool GameIsPaused = false;

    void Update()
    {
        PressPause();
    }

    public void PressPause()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
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
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        GameIsPaused = true;
        Time.timeScale = 0f;         
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene(0);
    }
}