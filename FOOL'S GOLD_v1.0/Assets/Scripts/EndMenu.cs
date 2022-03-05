using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    [SerializeField] GameObject endMenu;
    [SerializeField] Texture2D endMenuCursor;

    [SerializeField] ParticleSystem pickaxe;
    [SerializeField] ParticleSystem torch;

    public void TitleMenu()
    {
        SceneManager.LoadScene(0);
    }

    void Update()
    {
        if (endMenu.activeInHierarchy == true)
        {
            Cursor.SetCursor(endMenuCursor, Vector2.zero, CursorMode.Auto);

            torch.Stop();
            pickaxe.Stop();
        }
    }
}
