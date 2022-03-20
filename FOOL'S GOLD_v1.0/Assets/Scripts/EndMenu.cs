using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndMenu : MonoBehaviour
{
    [SerializeField] GameObject endMenu;
    [SerializeField] Texture2D endMenuCursor;

    [SerializeField] ParticleSystem pickaxe;
    [SerializeField] ParticleSystem torch;
    //[SerializeField] AudioManager audioManager;

    [SerializeField] TextMeshProUGUI endScore;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI endHighScoreText;

    public void TitleMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("highScore");
    }

    //public void clickAudio()
    //{
    //    FindObjectOfType<AudioManager>().PlaySound("MenuClick");
    //}

    void Update()
    {
        if (endMenu.activeInHierarchy == true)
        {
            Cursor.SetCursor(endMenuCursor, Vector2.zero, CursorMode.Auto);

            torch.Stop();
            pickaxe.Stop();
        }

        endScore.text = scoreText.text;
        endHighScoreText.text = LootScoreManager.highScore.ToString();

        //if (endMenu.activeInHierarchy && Input.GetMouseButtonDown(0))
        //{
        //    clickAudio();
        //}
    }
}
