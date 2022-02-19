using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SalesSpiritBehaviour : MonoBehaviour
{
    public InventoryBehaviour PlayerInventory;

    public GameObject Shelve;
    public Button ItemSlot;

    private List<Button> playerStock = new List<Button>();

    private void Awake()
    {
        DisplayStock();
        DisplayPlayerStock();
    }

    public void OpenInventory()
    {
        RefreshPlayerStock();

    }

    public void DisplayStock()
    {
        //add itemslots to shelve for each item in currenstock
        foreach(var seed in SeedType.types)
        {
            var button = Instantiate(ItemSlot, Shelve.transform);           
            button.onClick.AddListener(delegate { SellSeed(seed); });
            button.GetComponentInChildren<Text>().text = seed.Name + "price: " + seed.SellPrice; ;
        }

        foreach (var item in ItemType.types.Where(i => i.ID >= 2))
        {
            var button = Instantiate(ItemSlot, Shelve.transform);
            button.onClick.AddListener(delegate { SellItem(item); });
            button.GetComponentInChildren<Text>().text = item.Name + "price: " + item.SellPrice; ;
        }
    }

    public void DisplayPlayerStock()
    {
        //add itemslots to shelve for each item in currenstock
        foreach (var item in PlayerInventory.inventory.items)
        {
            var button = Instantiate(ItemSlot, Shelve.transform);
            playerStock.Add(button);
            var itemType = ItemType.types[item.ID];
            button.onClick.AddListener(delegate { BuyItem(itemType); });
            button.GetComponentInChildren<Text>().text = itemType.Name + "owned: " + item.amount + "price: " + itemType.BuyPrice;          
        }
        
    }

    public void BuyItem(ItemType item)
    {
        PlayerInventory.RemoveItem(item);
        RefreshPlayerStock();
        PlayerInventory.UpdateWallet(item.BuyPrice);
    }

    public void RefreshPlayerStock()
    {
        foreach(var button in playerStock)
        {
            Destroy(button.gameObject);
        }
        playerStock.Clear();
        DisplayPlayerStock();

    }

    public void SellSeed(SeedType seed)
    {
        if (PlayerInventory.CanAfford(seed.SellPrice))
        {
            //add item to player inventory
            PlayerInventory.AddSeed(seed);
            PlayerInventory.UpdateWallet(-seed.SellPrice);
        }       
    }

    public void SellItem(ItemType item)
    {
        if (PlayerInventory.CanAfford(item.SellPrice))
        {
            //add item to player inventory
            PlayerInventory.AddItem(item);
            PlayerInventory.UpdateWallet(-item.SellPrice);
        }
    }
}
