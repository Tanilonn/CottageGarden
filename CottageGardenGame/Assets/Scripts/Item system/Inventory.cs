﻿using System;
using System.Collections.Generic;

[Serializable]
public class Inventory
{
    private List<Item> items;

    public Inventory()
    {
        items = new List<Item>();
    }
    public void AddItem(Item item)
    {
        items.Add(item);
    }

    public void RemoveItem(Item item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
        }
    }

    public List<Item> GetItems()
    {
        return items;
    }


   
}
