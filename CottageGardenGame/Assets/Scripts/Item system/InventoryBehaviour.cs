using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryBehaviour : MonoBehaviour
{
    public Inventory inventory;
    public Dropdown dropDown;
    public int selectedSeed;
    public Text wallet;

    private void Awake()
    {
        inventory = SaveDataManager.gameData.Inventory;
        SetDropdownOptions();
        wallet.text = inventory.money.ToString();
    }

    public void AddSeed(SeedType seed)
    {
       if(HasSeed(seed.ID))
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
        if (HasSeed(seed.ID))
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

    public bool HasSeed(int seedID)
    {
        return inventory.seeds.Exists(s => s.ID == seedID);
    }

    //TODO: seed dropdown
    public void SetDropdownOptions()
    {
        List<string> list = GetNames();
        //Clear the old options of the Dropdown menu
        dropDown.ClearOptions();
        //Add the options created in the List above
        dropDown.AddOptions(list);
    }

    public int GetDropDownValue()
    {
        if(dropDown.options.Count == 0)
        {
            return -1;
        }
        else
        {
            return selectedSeed = inventory.seeds[dropDown.value].ID;
        }
    }

    public List<string> GetNames()
    {
        List<string> names = new List<string>();

        foreach (var seed in inventory.seeds)
        {
            names.Add(SeedType.types[seed.ID].Name);
        }
        return names;

    }

    public void AddItem(ItemType item)
    {
        if (HasItem(item.ID))
        {
            inventory.items.Find(s => s.ID == item.ID).amount++;
        }
        else
        {
            inventory.items.Add(new ItemAmount() { ID = item.ID, amount = 1 });
        }
        UpdateSaveData();
    }

    public void RemoveItem(ItemType item)
    {
        if (HasItem(item.ID))
        {
            var itemAmount = inventory.items.Find(s => s.ID == item.ID);
            if (itemAmount.amount > 0)
            {
                itemAmount.amount--;
            }
            else
            {
                inventory.items.Remove(itemAmount);
            }
        }
        UpdateSaveData();
    }

    public bool HasItem(int itemID)
    {
        return inventory.items.Exists(s => s.ID == itemID);
    }

    public void UpdateWallet(int amount)
    {
        inventory.money += amount;
        wallet.text = inventory.money.ToString();
    }

    public bool CanAfford(int amount)
    {
        return inventory.money >= amount;
    }

    public void UpdateSaveData()
    {
        SetDropdownOptions();

        SaveDataManager.gameData.Inventory = inventory;

    }


}
