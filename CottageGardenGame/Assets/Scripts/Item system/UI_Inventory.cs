using System.Collections;
using System.Collections.Generic;
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
        for(int i = 0; i < inventory.inventory.seeds.Count; i++)
        {
            GameObject slot = Instantiate(itemSlot, itemGrid.transform);
            slots.Add(slot);
            Text text = slot.GetComponentInChildren<Text>();
            text.text = SeedType.types[inventory.inventory.seeds[i].ID].Name + inventory.inventory.seeds[i].amount;
        }

    }

    //TODO: seed dropdown

    private void DestoryItems()
    {
        foreach(var item in slots)
        {
            Destroy(item);
        }
        slots.Clear();
    }
}
