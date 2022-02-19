using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WorldBehaviour : MonoBehaviour
{
    public World world;
    public Tilemap tilemap;
    public Tilemap plantMap;
    public List<TileBase> startTiles;
    public List<TileBase> plantTiles;
    public List<TileBase> itemTiles;
    public BoundsInt area;

    private List<Vector3Int> allTileLocations = new List<Vector3Int>();

    private void Awake()
    {
        if(SaveDataManager.gameData.World.tiles != null)
        {
            world = SaveDataManager.gameData.World;
            LoadTileMap();
            InitItems();
        }
        //create the tilemap
        else
        {
            CreateTileMap();            
        }
        //TODO: render all plants

        InvokeRepeating("GrowPlants", 0f, 5f);
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager.RandomPlantEvent += GameManager_RandomPlantEvent;
    }

    private void GameManager_RandomPlantEvent(object sender, System.EventArgs e)
    {
        var tile = RandomFreeTile();
        var random = new System.Random();
        var seed = SeedType.types[random.Next(SeedType.types.Count)];
        AddPlant(seed, tile);
        Debug.Log("RANDOM SEED EVENT! plant added: " + seed.Name);
    }

    public void ChangeTerrain(int tool, Vector3Int tile)
    {
        //the tool determines where in the list we search, for now 1=water, 2=dirt, 3=stone, 4=grass
        tilemap.SetTile(tile, startTiles[tool-1]);
        world.tiles[getIndex(tile)] = tool - 1;
       
        //the surrounding tiles determine which tile is used
        //the surrouding tiles need to be changed as well
        UpdateSaveData();
    }

    public bool AddPlant(SeedType seed, Vector3Int tile)
    {
        //check if tile is free
        if (!world.plants.Exists(p => p.Location == tile))
        {
            //create plant at tile
            var plant = new PlantTile() { ID = seed.ID, Location = tile, Growth = 0 };
            world.plants.Add(plant);
            //TODO: render plant
            plantMap.SetTile(tile, plantTiles[0]);
            UpdateSaveData();
            return true;
        }
        else
        {
            return false;
        }
    }

    public int RemovePlant(Vector3Int tile)
    {
        var plant = world.plants.Find(p => p.Location == tile);

        if (plant !=null && plant.Growth > PlantType.types[plant.ID].GrowPeriod)
        {
            //ready to harvest
            //TODO: fruit cycle (if plant has fruit cycle, reset and don't remove, else remove)
            world.plants.Remove(plant);
            plantMap.SetTile(tile, null);
            UpdateSaveData();
            return plant.ID;
        }
        else
        {
            return -1;
        }

    }

    public void GrowPlants()
    {
        foreach(var plant in world.plants)
        {
            plant.Growth++;
            if(plant.Growth > PlantType.types[plant.ID].GrowPeriod)
            {
                plantMap.SetTile(plant.Location, plantTiles[1]);
            }
        }
    }


    public bool AddItem(ItemType item, Vector3Int tile)
    {
        //check if tile is free
        if (TileIsFree(tile))
        {
            //create plant at tile
            var itemTile = new ItemTile() { ID = item.ID, Location = tile };
            world.items.Add(itemTile);
            //TODO: render plant
            plantMap.SetTile(tile, itemTiles[0]);
            UpdateSaveData();
            return true;
        }
        else
        {
            return false;
        }
    }

    public int RemoveItem(Vector3Int tile)
    {
        var item = world.items.Find(p => p.Location == tile);

        if (item != null)
        {           
            world.items.Remove(item);
            plantMap.SetTile(tile, null);
            UpdateSaveData();
            return item.ID;
        }
        else
        {
            return -1;
        }

    }

    private bool TileIsFree(Vector3Int tile)
    {
        if(plantMap.GetTile(tile) == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private Vector3Int RandomFreeTile()
    {
        //create a list of free tiles
        var tiles = new List<Vector3Int>();
        foreach (var pos in allTileLocations)
        {
            if (plantMap.GetTile(pos) == null) tiles.Add(pos);
        }      
        
        var random = new System.Random();
        return tiles[random.Next(tiles.Count)];
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    private void UpdateSaveData()
    {
        SaveDataManager.gameData.World = world;
    }

    private void LoadTileMap()
    {
        var indexTile = 0;
        for (int w = 0; w < 10; w++)
        {
            for (int h = 0; h < 10; h++)
            {
                //draw a tile at position
                var pos = new Vector3Int(w, h, 0);
                var tile = startTiles[world.tiles[indexTile]];
                tilemap.SetTile(pos, tile);
                indexTile++;
                allTileLocations.Add(pos);
            }
        }
    }

    private void InitItems()
    {
        foreach(var item in world.items)
        {
            plantMap.SetTile(item.Location, itemTiles[0]);
        }
        foreach (var plant in world.plants)
        {
            plantMap.SetTile(plant.Location, plantTiles[0]);
        }
    }

    private void CreateTileMap()
    {
        for (int w = 0; w < 10; w++)
        {
            for (int h = 0; h < 10; h++)
            {
                //draw a tile at position
                var pos = new Vector3Int(w, h, 0);
                var tile = startTiles[Random.Range(0, 2)];
                tilemap.SetTile(pos, tile);
                world.tiles.Add(startTiles.IndexOf(tile));
                allTileLocations.Add(pos);
            }
        }
        UpdateSaveData();
        SaveDataManager.Save();
    }


    private int getIndex(Vector3Int tile)
    {
        return tile.x * 10 + tile.y;
    }


}
