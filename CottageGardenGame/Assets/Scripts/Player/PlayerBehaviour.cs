using System.Collections;
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
        player.SelectedItem = inventory.GetSelectedItem();


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
        controls.Garden.PlantSeed.performed += c => WaterPlant();
        controls.Garden.PlantSeed.performed += c => HarvestPlant();
        controls.Garden.PlantSeed.performed += c => PickUpItem();
        controls.Garden.PlantSeed.performed += c => PlaceItem();
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
                    UpdateSaveData();
                }
            }           
        }
    }

    private void WaterPlant()
    {
        if (player.SelectedTool == Tool.Water)
        {
            Debug.Log("water");
            var plant = world.GetPlantOrDefault(Vector3Int.FloorToInt(transform.position));
            if (plant != null)
            {
                Debug.Log("watered:" +plant.Growth);
                plant.Water();
                Debug.Log(plant.Growth);

            }
        }         
    }

    private void HarvestPlant()
    {
        var plantID = world.RemovePlant(Vector3Int.FloorToInt(transform.position));
        if (plantID >= 0)
        {
            inventory.AddItem(ItemType.types[plantID]);
            UpdateSaveData();
        }
    }

    private void PlaceItem()
    {
        var itemID = player.SelectedItem = inventory.GetSelectedItem();
        if(itemID >= 0)
        {
            var item = ItemType.types[player.SelectedItem];
            //check if selectedseed is in inventory
            if (inventory.HasItem(player.SelectedItem))
            {
                //if succesfully added remove from inventory       
                if (world.AddItem(item, Vector3Int.FloorToInt(transform.position)))
                {
                    inventory.RemoveItem(item);
                    inventory.selectedItem = -1;
                    player.SelectedItem = -1;
                    UpdateSaveData();
                }
            }
        }
    }

    private void PickUpItem()
    {
        var itemID = world.RemoveItem(Vector3Int.FloorToInt(transform.position));
        if (itemID >= 0)
        {
            //add plant to inventory
            inventory.AddItem(ItemType.types[itemID]);
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
        UpdateSaveData();
    }

    private void UpdateSaveData()
    {
        SaveDataManager.gameData.Player = player;
    }

   
   
}
