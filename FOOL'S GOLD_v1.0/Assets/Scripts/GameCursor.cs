using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCursor : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Button backpackBtn;

    [SerializeField] Texture2D searchingCursorTexture;
    [SerializeField] Texture2D miningCursorTexture;

    [SerializeField] ParticleSystem pickaxe;
    [SerializeField] ParticleSystem torch;

    public bool isPickaxe;


    void Start()
    {
        SetSearchingCursor(searchingCursorTexture, torch);
        isPickaxe = false;
        backpackBtn.onClick.AddListener(TogglePickaxe);
    }

    public void SetSearchingCursor(Texture2D texture, ParticleSystem partSys)
    {
        Cursor.SetCursor(searchingCursorTexture, Vector2.zero, CursorMode.Auto);
        torch.Play();
        pickaxe.Stop();
        pickaxe.Clear();
    }

    public void SetMiningCursor(Texture2D texture, ParticleSystem partSys)
    {

        Cursor.SetCursor(miningCursorTexture, Vector2.zero, CursorMode.Auto);
        pickaxe.Play();
        torch.Stop();
        torch.Clear();
    }

    public void TogglePickaxe()
    {
        if (!isPickaxe)
        {
            isPickaxe = true;
            SetMiningCursor(miningCursorTexture, pickaxe);
        }
        else if (isPickaxe)
        {
            isPickaxe = false;
            SetSearchingCursor(searchingCursorTexture, torch);
        }
    }
}