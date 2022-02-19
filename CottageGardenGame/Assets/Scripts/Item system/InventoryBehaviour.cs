using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryBehaviour : MonoBehaviour
{
    public Inventory inventory;

    private void Awake()
    {
        inventory = SaveDataManager.gameData.Inventory;
    }

    public void AddSeed(SeedType seed)
    {
       if(inventory.seeds.Exists(s => s.ID == seed.ID))
        {
            inventory.seeds.Find(s => s.ID == seed.ID).amount++;
        }
        else
        {
            inventory.seeds.Add(new SeedAmount() { ID = seed.ID, amount = 1 }) ; 
        }
        UpdateSaveData();
    }

    public void RemoveSeed(SeedType seed)
    {
        if (inventory.seeds.Exists(s => s.ID == seed.ID))
        {
            var seedAmount = inventory.seeds.Find(s => s.ID == seed.ID);
            if(seedAmount.amount > 0)
            {
                seedAmount.amount--;
            }
            else
            {
                inventory.seeds.Remove(seedAmount);
            }
        }
        UpdateSaveData();
    }

    public void UpdateSaveData()
    {
        SaveDataManager.gameData.Inventory = inventory;

    }


}
