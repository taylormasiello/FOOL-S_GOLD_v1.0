using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCursor : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Button backpackBtn;
    //[SerializeField] GameCursor gameCursor;

    [SerializeField] Texture2D searchingCursorTexture;
    [SerializeField] Texture2D miningCursorTexture;

    [SerializeField] ParticleSystem pickaxe;
    [SerializeField] ParticleSystem torch;
    //[SerializeField] ParticleSystem pauseMenu;
    //[SerializeField] ParticleSystem endMenu;

    //public Vector3 cursorPos;
    public bool isPickaxe;

    //void Awake()
    //{
    //    Vector3 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    gameCursor = GameObject.Find("GameCursor").GetComponent<GameCursor>();
    //    gameCursor.transform.position = cursorPos;
    //}

    void Start()
    {
        SetSearchingCursor(searchingCursorTexture, torch);
        isPickaxe = false;
        backpackBtn.onClick.AddListener(TogglePickaxe);
    }

    public void SetSearchingCursor(Texture2D texture, ParticleSystem partSys)
    {
        //Vector3 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Cursor.SetCursor(searchingCursorTexture, Vector2.zero, CursorMode.Auto);
        //torch.transform.localPosition = cursorPos;
        //torch.transform.TransformVector(cursorPos);
        //Instantiate(torch, cursorPos, Quaternion.identity);
        torch.Play();
        pickaxe.Stop();

    }

    public void SetMiningCursor(Texture2D texture, ParticleSystem partSys)
    {

        Cursor.SetCursor(miningCursorTexture, Vector2.zero, CursorMode.Auto);
        //pickaxe.transform.position = cursorPos;
        //pickaxe.transform.TransformVector(cursorPos);
        //Instantiate(pickaxe, cursorPos, Quaternion.identity);
        pickaxe.Play();
        torch.Stop();
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