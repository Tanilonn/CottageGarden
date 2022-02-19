using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[Serializable]
public class Inventory
{
    public List<SeedAmount> seeds = new List<SeedAmount>();
    public List<ItemAmount> items = new List<ItemAmount>();
    public int money = 50;

}
