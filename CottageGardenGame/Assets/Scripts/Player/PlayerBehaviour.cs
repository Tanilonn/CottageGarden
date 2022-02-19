﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        controls.Garden.PlantSeed.performed += c => PlantSeed();
        controls.Garden.PlantSeed.performed += c => HarvestPlant();
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
        var seedID = player.SelectedSeed = inventory.GetDropDownValue();
        if (seedID >= 0) { 
            var seed = SeedType.types[player.SelectedSeed];
            //check if selectedseed is in inventory
            if (inventory.HasSeed(player.SelectedSeed))
            {
                //if succesfully added remove from inventory       
                if (world.AddPlant(seed, Vector3Int.FloorToInt(transform.position)))
                {
                    inventory.RemoveSeed(seed);
                    Debug.Log("planted plant: " + PlantType.types[seed.ID]);
                }
            }           
        }
    }

    private void HarvestPlant()
    {
        var plantID = world.RemovePlant(Vector3Int.FloorToInt(transform.position));
        if (plantID >= 0)
        {
            //add plant to inventory
            inventory.AddItem(ItemType.types[plantID]);
            Debug.Log("harvested plant: " + PlantType.types[plantID]);
        }
    }

    public void ChangeSelectedTool(int tool)
    {
        player.SelectedTool = (Tool)tool;
        UpdateSaveData();
    }

    public void ChangeSelectedSeed(Dropdown dropdown)
    {
        player.SelectedSeed = inventory.GetDropDownValue();
        Debug.Log(SeedType.types[player.SelectedSeed].Name);
    }

    private void UpdateSaveData()
    {
        SaveDataManager.gameData.Player = player;
    }

   
   
}
