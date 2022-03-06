
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;
//using UnityEngine.UIElements;
using UnityEngine.Tilemaps;

public class ToMine : MonoBehaviour
{
    [SerializeField] Grid tilemapGrid;
    [SerializeField] Tilemap rockTilemap;
    [SerializeField] Rigidbody2D playerRb;

    [SerializeField] GameCursor gameCursorScript;
    [SerializeField] GameObject miningInfoBox;
    [SerializeField] Slider miningProgress;

    //[SerializeField] GameObject realGoldBox;
    //[SerializeField] GameObject foolsGoldBox;

    [SerializeField] Vector3 maxOffset = new Vector3(2f, 2f, 2f);

    public bool canMove;
    // public int miningCounter;

    //public bool finishedMining;

    void Start()
    {
        InvokeRepeating("ProgressChange", 0.1f, 0.1f);
        //InvokeRepeating("LootDrop", 1f, 1f);

        miningProgress.value = 0;
        //miningCounter = 0;
        canMove = true;
        //isMining = false;
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


            //finishedMining = true;
            //Debug.Log(finishedMining);
        }
    }

    //void FixedUpdate()
    //{
    //    playerFreeze();    
    //}

    void Update()
    {
        ClickOnRock();
        // LootDrop();
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
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mousePosNoZ = new Vector3(mousePos.x, mousePos.y);// cursor pos, world

        Vector3Int mouseTileCell = tilemapGrid.WorldToCell(mousePosNoZ); // cursor pos, cell
        TileBase tileUnderCursor = rockTilemap.GetTile(mouseTileCell); // Rock under cursor       

        Vector3 playerPos = playerRb.transform.position;
        Vector3 playerPosNoZ = new Vector3(playerPos.x, playerPos.y); //player pos, world

        Vector3Int playerTileCell = tilemapGrid.WorldToCell(playerPosNoZ); //player pos, cell
        TileBase tileUnderPlayer = rockTilemap.GetTile(playerTileCell); //tile under player

        if (PlayerInOffset(mousePosNoZ, playerPosNoZ, maxOffset) && ComparedTilesInOffset(mouseTileCell, playerTileCell, maxOffset) && (gameCursorScript.isPickaxe == true) && (tileUnderCursor != tileUnderPlayer))
        {
            if (Input.GetMouseButtonDown(0))
            {

                
                Mining();
                // LootScoreManager.instance.LootDrop();
                //miningCounter++;
                //Debug.Log(miningCounter);
                //LootDrop();

                //Instantiate(miningInfoBox);
                //isMining = true;

                //delete cell of rock
                canMove = true;
/*                LootDrop(); *///show either real or fool's gold card + logic

            }
        }
    }

    void Mining()
    {
        //isMining = true;
        miningInfoBox.SetActive(true);
        //finishedMining = false;
        canMove = false;
        //Debug.Log(finishedMining); 

        miningProgress.minValue = 0f;
        miningProgress.maxValue = Random.Range(0.5f, 2.5f);
        miningProgress.value = 0f;

        if(miningProgress.value <= 0.01f)
        {
            LootScoreManager.instance.LootDrop();
        }
    }



    //void LootDrop()
    //{
    //    float timeDropShown = 4f;
    //    //int dropRate = Random.Range(1, 9);

    //    if (finishedMining)
    //    {
    //        timeDropShown -= Time.time;

    //        if (timeDropShown > 0.02f)
    //        {
    //            //if (dropRate % 3 == 0)
    //            //{
    //            //    //realGoldBox.SetActive(true);
    //            //    // Debug.Log("realGold");
    //            //    //increment score
    //            //}
    //            //else
    //            //{
    //            //    //foolsGoldBox.SetActive(true);
    //            //    // Debug.Log("foolsGold");
    //            //}
    //        }
    //        else if (timeDropShown <= 0.01f)
    //        {
    //            //realGoldBox.SetActive(false);
    //            //foolsGoldBox.SetActive(false);

    //            return;
    //        }
    //    }
    //}

    //void playerFreeze()
    //{
    //    Vector3 playerWorldPos = playerRb.transform.position;

    //    if (!canMove)
    //    {
    //        playerRb.MovePosition(playerRb.position * 0 * Time.fixedDeltaTime);
    //    }
    //}
}