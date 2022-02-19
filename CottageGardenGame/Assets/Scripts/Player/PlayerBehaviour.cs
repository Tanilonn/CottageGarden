using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public Player player;
    public float speed;
    public UI_Inventory UIinventory;
    public WorldBehaviour world;
    public InventoryBehaviour inventory;

    private PlayerActions controls;


    private void Awake()
    {
        controls = new PlayerActions();
        player = SaveDataManager.gameData.Player;
        transform.position = player.Location;


        //Inventory = SaveDataManager.gameData.inventory;
    UIinventory.SetInventory(inventory);

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

    private void PlantSeed()
    {
        //add event for planting a seed on P key
        //todo: create dropdown menu from inventory seeds
        //check if any seed is selected in dropdown
        //remove seed from inventory
        //add plant to tile

        //optional: use one key for all plant interactions, check the status of the tile first (empty, has plant, has grown plant)
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

   
   
}
