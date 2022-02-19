using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WorldBehaviour : MonoBehaviour
{
    public World world;
    public Tilemap tilemap;
    public Tilemap plantMap;
    public List<TileBase> singleTiles;
    public List<TileBase> centerTiles;
    public List<TileBase> borderTiles;
    public List<TileBase> cornerTiles;
    public List<TileBase> connectTile;
    public List<TileBase> uTiles;

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
        //for saving
        var terrainType = tool - 1;
        if(getIndex(tile) > 0)
        {
            world.tiles[getIndex(tile)] = terrainType;

            LoadAroundTile(tile);

            UpdateSaveData();
        }
       
    }

    private void SetTexture(int terrainType, Vector3Int tile)
    {
        //the tool determines where in the list we search, for now 1=water, 2=dirt, 3=stone, 4=grass
        var vtop = tile + new Vector3Int(0, 1, 0);
        var vbottom = tile + new Vector3Int(0, -1, 0);
        var vleft = tile + new Vector3Int(-1, 0, 0);
        var vright = tile + new Vector3Int(1, 0, 0);

        //get the terrain type of top, bottom, left and right
        var top = getTerrain(getIndex(vtop));
        var bottom = getTerrain(getIndex(vbottom));
        var left = getTerrain(getIndex(vleft));
        var right = getTerrain(getIndex(vright));

        List<int> surrounding = new List<int> { top, bottom, left, right };
        var sameType = surrounding.Count(s => s == terrainType);

        //the surrounding tiles determine which tile is used
        //if there are no tiles of the same type around, use the single tile
        if (sameType == 0)
        {
            tilemap.SetTile(tile, singleTiles[terrainType]);
        }
        //if there is one tile of the same type around, use the C U tiles       
        else if (sameType == 1)
        {
            if (top == terrainType)
            {
                tilemap.SetTile(tile, uTiles[terrainType]);
            }
            else if (bottom == terrainType)
            {
                tilemap.SetTile(tile, uTiles[terrainType + 4]);
            }
            else if (left == terrainType)
            {
                tilemap.SetTile(tile, uTiles[terrainType + 8]);
            }
            else if (right == terrainType)
            {
                tilemap.SetTile(tile, uTiles[terrainType + 12]);
            }
        }
        //if there is 2 tiles, use a corner piece or a connector piece
        else if (sameType == 2)
        {
            if (top == terrainType && bottom == terrainType)
            {
                tilemap.SetTile(tile, connectTile[terrainType]);
            }
            else if (left == terrainType && right == terrainType)
            {
                tilemap.SetTile(tile, connectTile[terrainType + 4]);
            }
            else if (left == terrainType && top == terrainType)
            {
                tilemap.SetTile(tile, cornerTiles[terrainType]);
            }
            else if (right == terrainType && top == terrainType)
            {
                tilemap.SetTile(tile, cornerTiles[terrainType + 4]);
            }
            else if (left == terrainType && bottom == terrainType)
            {
                tilemap.SetTile(tile, cornerTiles[terrainType + 8]);
            }
            else if (right == terrainType && bottom == terrainType)
            {
                tilemap.SetTile(tile, cornerTiles[terrainType + 12]);
            }
        }
        //if there is 3 tiles, use a border piece
        else if (sameType == 3)
        {
            if (top != terrainType)
            {
                tilemap.SetTile(tile, borderTiles[terrainType]);
            }
            else if (bottom != terrainType)
            {
                tilemap.SetTile(tile, borderTiles[terrainType + 4]);
            }
            else if (left != terrainType)
            {
                tilemap.SetTile(tile, borderTiles[terrainType + 8]);
            }
            else if (right != terrainType)
            {
                tilemap.SetTile(tile, borderTiles[terrainType + 12]);

            }
        }
        //if there is 4 tiles, use center piece
        else if (sameType == 4)
        {
            tilemap.SetTile(tile, centerTiles[terrainType]);
        }       

    }

    public bool AddPlant(SeedType seed, Vector3Int tile)
    {
        //check if tile is free
        if (!world.plants.Exists(p => p.Location == tile))
        {
            //create plant at tile
            var plant = new PlantTile() { ID = seed.ID, Location = tile, Growth = 0 };
            world.plants.Add(plant);
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

    public PlantTile GetPlantOrDefault(Vector3Int tile)
    {
        return world.plants.Find(p => p.Location == tile);
    }


    public bool AddItem(ItemType item, Vector3Int tile)
    {
        //check if tile is free
        if (TileIsFree(tile))
        {
            //create plant at tile
            var itemTile = new ItemTile() { ID = item.ID, Location = tile };
            world.items.Add(itemTile);
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
                SetTexture(world.tiles[indexTile], pos);
                indexTile++;
                allTileLocations.Add(pos);
            }
        }
    }

    private void LoadAroundTile(Vector3Int tile)
    {
        var start = tile + new Vector3Int(-1, -1, 0);
        var startIndex = getIndex(start);

        for (int w = start.x; w < start.x + 3; w++)
        {
            for (int h = start.y; h < start.y + 3; h++)
            {
                //draw a tile at position
                var pos = new Vector3Int(w, h, 0);
                startIndex = getIndex(pos);
                if (startIndex >= 0)
                {
                    SetTexture(world.tiles[startIndex], pos);
                }                
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
                var tile = singleTiles[Random.Range(0, 2)];
                tilemap.SetTile(pos, tile);
                world.tiles.Add(singleTiles.IndexOf(tile));
                allTileLocations.Add(pos);
            }
        }
        UpdateSaveData();
        SaveDataManager.Save();
    }


    private int getIndex(Vector3Int tile)
    {
        if(tile.x < 0 || tile.y < 0 || tile.x > 9 || tile.y > 9)
        {
            //invalid input
            return -1;
        }
        return tile.x * 10 + tile.y;
    }

    private int getTerrain(int tile)
    {
        if (tile < 0 || tile > 99)
        {
            //negative tile, invalid input
            return -1;
        }
        else return world.tiles[tile];
    }


}
