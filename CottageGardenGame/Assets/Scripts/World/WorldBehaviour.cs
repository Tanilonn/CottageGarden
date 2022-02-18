using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WorldBehaviour : MonoBehaviour
{
    public World world;
    public Tilemap tilemap;
    public List<TileBase> startTiles;
    public BoundsInt area;

    private void Awake()
    {
        if(SaveDataManager.gameData.World.tiles != null)
        {
            world = SaveDataManager.gameData.World;
            LoadTileMap();
        }
        //create the tilemap
        else
        {
            CreateTileMap();            
        }
    }

    public void ChangeTerrain(int tool, Vector3Int tile)
    {

        //the tool determines where in the list we search, for now 1=water, 2=dirt, 3=stone, 4=grass
        tilemap.SetTile(tile, startTiles[tool-1]);
        world.tiles[getIndex(tile)] = tool - 1;
        //there is a list of all available tiles
        //the list is ordered by terrain
        //which tool is selected determines which type is used
        //the surrounding tiles determine which tile is used
        //the surrouding tiles need to be changed as well
        UpdateSaveData();
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
            }
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
