
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;
//using UnityEngine.UIElements;
using UnityEngine.Tilemaps;
using CodeMonkey.Utils;

public class ToMine : MonoBehaviour
{
    [SerializeField] Grid tilemapGrid;
    [SerializeField] Tilemap rockTilemap;
    [SerializeField] Rigidbody2D playerRb;

    [SerializeField] GameCursor gameCursorScript;
    [SerializeField] GameObject miningInfoBox;
    [SerializeField] Slider miningProgress;

    [SerializeField] ParticleSystem pickaxe;
    [SerializeField] ParticleSystem torch;

    [SerializeField] private FieldOfView fieldOfView;
    [SerializeField] private GameObject pickaxeFov;

    [SerializeField] Vector3 maxOffset = new Vector3(2f, 2f, 2f);

    Vector3 mousePos;

    void Start()
    {
        pickaxeFov.SetActive(false);
        Cursor.visible = true;
        InvokeRepeating("ProgressChange", 0.1f, 0.1f);
        miningProgress.value = 0;
    }

    void ProgressChange()
    {
        if (miningProgress.value < miningProgress.maxValue)
        {
            miningProgress.value += 0.25f;
        }
        else if (miningProgress.value >= miningProgress.maxValue)
        {
            miningInfoBox.SetActive(false);
        }
    }


    void Update()
    {
        ClickOnRock();

        if (!miningInfoBox.activeInHierarchy)
        {
            Cursor.visible = true;
        }
        else if (miningInfoBox.activeInHierarchy)
        {
            Cursor.visible = false;

            pickaxe.Stop();
            pickaxe.Clear();
            torch.Stop();
            torch.Clear();
        }
    }

    void LateUpdate()
    {
        fieldOfView.PickaxeFieldOfView();
        
        if (gameCursorScript.isPickaxe)
        {
            pickaxeFov.SetActive(true);
        } else if (!gameCursorScript.isPickaxe)
        {
            pickaxeFov.SetActive(false);
        }
        
    }

    bool PlayerInOffset(Vector3 pos1, Vector3 pos2, Vector3 offset) // compares cursor pos world & player pos world to offset
    {
        return System.Math.Abs(pos1.x - pos2.x) <= offset.x && System.Math.Abs(pos1.y - pos2.y) <= offset.y;
    }

    bool ComparedTilesInOffset(Vector3 tile1Pos, Vector3 tile2Pos, Vector3 offset) // offset value is per tile
    {
        return (tile1Pos.x - tile2Pos.x) <= offset.x && (tile1Pos.y - tile2Pos.y) <= offset.y;
    }

    void ClickOnRock()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mousePosNoZ = new Vector3(mousePos.x, mousePos.y);// cursor pos, world

        Vector3Int mouseTileCell = tilemapGrid.WorldToCell(mousePosNoZ); // cursor pos, cell
        TileBase tileUnderCursor = rockTilemap.GetTile(mouseTileCell); // Rock under cursor       

        Vector3 playerPos = playerRb.transform.position;
        Vector3 playerPosNoZ = new Vector3(playerPos.x, playerPos.y); //player pos, world

        Vector3Int playerTileCell = tilemapGrid.WorldToCell(playerPosNoZ); //player pos, cell
        TileBase tileUnderPlayer = rockTilemap.GetTile(playerTileCell); //tile under player

        fieldOfView.SetCursorDirection(UtilsClass.GetMouseWorldPosition() - playerPos);
        fieldOfView.SetOrigin(playerPosNoZ);              

        if (PlayerInOffset(mousePosNoZ, playerPosNoZ, maxOffset) && ComparedTilesInOffset(mouseTileCell, playerTileCell, maxOffset) && (gameCursorScript.isPickaxe == true) && (tileUnderCursor != tileUnderPlayer))
        {
            if (Input.GetMouseButtonDown(0))
            {                
                Mining();
                rockTilemap.SetTile(mouseTileCell, null);
            }
        }
    }

    void Mining()
    {
        miningInfoBox.SetActive(true);

        miningProgress.minValue = 0f;
        miningProgress.maxValue = Random.Range(0.5f, 1.5f);
        miningProgress.value = 0f;

        if(miningProgress.value <= 0.01f)
        {
            LootScoreManager.instance.LootDrop();
        }
    }
}