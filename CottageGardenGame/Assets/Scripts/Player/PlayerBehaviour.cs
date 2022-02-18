using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public Player player;
    public float speed;
    public UI_Inventory UIinventory;
    public WorldBehaviour world;

    private Vector2 movement;
    private PlayerActions controls;


    private void Awake()
    {
        controls = new PlayerActions();
        player = SaveDataManager.gameData.Player;
        transform.position = player.Location;


        //Inventory = SaveDataManager.gameData.inventory;
    UIinventory.SetInventory(player.Inventory);
        //transform.position = SaveDataManager.gameData.playerLocation;
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        //subscribe to input system event
        controls.Garden.Move.performed += c => Move(c.ReadValue<Vector2>());
        controls.Garden.UseTool.performed += c => UseTool();
    }

    private void Move(Vector2 direction)
    {
        transform.position += (Vector3)direction;
        player.Location = transform.position;
        UpdateSaveData();
    }

    private void UseTool()
    {
        if (player.SelectedTool != Tool.Hand)
        {
            Debug.Log((int)player.SelectedTool + "position: " + Vector3Int.FloorToInt(transform.position));
            world.ChangeTerrain((int)player.SelectedTool, Vector3Int.FloorToInt(transform.position));
        }
    }

    public void ChangeSelectedTool(int tool)
    {
        player.SelectedTool = (Tool)tool;
        UpdateSaveData();
    }

    private void UpdateSaveData()
    {
        SaveDataManager.gameData.Player = player;
    }

    //controls.Garden.UseTool 
    //check if any tool is selected
    //check which tool is selected
    //should use the currently active tool on the tile, 
    //what tool is active determines what this does to the terrain

   
}
