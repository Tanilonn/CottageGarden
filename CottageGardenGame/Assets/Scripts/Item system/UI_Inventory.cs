using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    public GameObject inventoryCanvas;
    public GameObject itemSlot;
    public GameObject itemGrid;
    public InventoryBehaviour inventory;
    private List<GameObject> slots = new List<GameObject>();


    // Update is called once per frame
    void Update()
    {
    }

    public void OpenInventory()
    {
        inventoryCanvas.SetActive(!inventoryCanvas.activeSelf);

        ShowItems();

    }

    public void Close()
    {
        DestoryItems();

        inventoryCanvas.SetActive(false);
    }

    public void SetInventory(InventoryBehaviour inventory)
    {
        this.inventory = inventory;
    }



    private void ShowItems()
    {
        foreach (var seed in inventory.inventory.seeds)
        {
            GameObject slot = Instantiate(itemSlot, itemGrid.transform);
            slots.Add(slot);
            Text text = slot.GetComponentInChildren<Text>();
            text.text = SeedType.types[seed.ID].Name + seed.amount;
        }
        foreach (var item in inventory.inventory.items)
        {
            GameObject slot = Instantiate(itemSlot, itemGrid.transform);
            slots.Add(slot);
            Text text = slot.GetComponentInChildren<Text>();
            text.text = ItemType.types[item.ID].Name + item.amount;
        }

    }

    

    private void DestoryItems()
    {
        foreach(var item in slots)
        {
            Destroy(item);
        }
        slots.Clear();
    }
}
