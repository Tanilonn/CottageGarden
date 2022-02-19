﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[Serializable]
public class World
{
    public List<int> tiles;
    public List<PlantTile> plants;
    public List<ItemTile> items;
}
