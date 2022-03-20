using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCursor : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Button backpackBtn;
    [SerializeField] GameObject miningInfoBox;

    [SerializeField] Texture2D searchingCursorTexture;
    [SerializeField] Texture2D miningCursorTexture;

    [SerializeField] ParticleSystem pickaxe;
    [SerializeField] ParticleSystem torch;
    
    public bool isPickaxe;
    public bool isTorch;

    void Awake()
    {
        SetSearchingCursor(searchingCursorTexture, torch);
    }

    void Start()
    {
        isPickaxe = false;
        isTorch = true;
        InvokeRepeating("ToggleEffects", 0.1f, 0.1f);
        backpackBtn.onClick.AddListener(TogglePickaxe);
    }

    public void SetSearchingCursor(Texture2D texture, ParticleSystem partSys)
    {
        Cursor.SetCursor(searchingCursorTexture, Vector2.zero, CursorMode.Auto);
        isTorch = true;

        if (searchingCursorTexture)
        {
            FindObjectOfType<AudioManager>().StopSound("PickaxeEquip");
            FindObjectOfType<AudioManager>().PlaySound("TorchEquip");
        }        
    }

    public void SetMiningCursor(Texture2D texture, ParticleSystem partSys)
    {
        Cursor.SetCursor(miningCursorTexture, Vector2.zero, CursorMode.Auto);
        isTorch = false;

        if (miningCursorTexture)
        {
            FindObjectOfType<AudioManager>().StopSound("TorchEquip");
            FindObjectOfType<AudioManager>().PlaySound("PickaxeEquip");
        }          
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

    void ToggleEffects()
    {
        if(isTorch)
        {
            torch.Play();
            pickaxe.Stop();
            pickaxe.Clear();

        }
        else
        {
            pickaxe.Play();
            torch.Stop();
            torch.Clear();
        }

    }
}