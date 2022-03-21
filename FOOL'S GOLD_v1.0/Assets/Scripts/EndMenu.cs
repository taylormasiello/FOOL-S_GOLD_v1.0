using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndMenu : MonoBehaviour
{
    [SerializeField] GameObject endMenu;
    [SerializeField] Texture2D endMenuCursor;

    [SerializeField] ParticleSystem pickaxe;
    [SerializeField] ParticleSystem torch;
    
    [SerializeField] TextMeshProUGUI endScore;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI endHighScoreText;

    void Awake()
    {
        Cursor.SetCursor(endMenuCursor, Vector2.zero, CursorMode.Auto);
    }

    public void TitleMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("highScore");
    }

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
    }
}
