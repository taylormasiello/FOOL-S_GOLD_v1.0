using System.Collections;
using System.Collections.Generic;
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

    //public void clickAudio()
    //{
    //    FindObjectOfType<AudioManager>().PlaySound("MenuClick");
    //}

    void Start()
    {
        Time.timeScale = 0;
        Cursor.SetCursor(menuCursor, Vector2.zero, CursorMode.Auto);
    }

    void Update()
    {
        //if (mainMenuUI.activeInHierarchy && Input.GetMouseButtonDown(0))
        //{
        //    clickAudio();
        //}
    }
}
