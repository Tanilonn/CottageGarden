using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SalesSpiritBehaviour : MonoBehaviour
{
    public InventoryBehaviour PlayerInventory;

    public GameObject Shelve;
    public Button ItemSlot;

    private void Awake()
    {
        DisplayStock();
    }

    public void DisplayStock()
    {
        //add itemslots to shelve for each item in currenstock
        foreach(var seed in SeedType.types)
        {
            Debug.Log(seed.Name);
            var button = Instantiate(ItemSlot, Shelve.transform);           
            button.onClick.AddListener(delegate { SellItem(seed); });
        }
    }

    public void SellItem(SeedType seed)
    {
        //add item to player inventory
        PlayerInventory.AddSeed(seed);
    }
}
