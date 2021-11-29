using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    public GameObject inventoryCanvas;
    public GameObject itemSlot;
    public Inventory inventory;
    private List<GameObject> slots;

    // Start is called before the first frame update
    void Start()
    {
        slots = new List<GameObject>();
        CreateItemSlots();
        ShowItems();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenInventory()
    {
        inventoryCanvas.SetActive(!inventoryCanvas.activeSelf);
        ShowItems();
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
    }

    private void CreateItemSlots()
    {
        for(int x =0; x<9; x++)
        {
            for(int y = 0; y < 4; y++)
            {
                Vector3 position = new Vector3(x*50, y*-50, 0);
                GameObject slot = Instantiate(itemSlot, this.transform);
                slot.SetActive(true);
                Transform trans = slot.GetComponent<Transform>();
                trans.position += position;
                slots.Add(slot);
            }
        }
    }

    private void ShowItems()
    {
        List<Item> items = inventory.GetItems();
        for(int i = 0; i < items.Count; i++)
        {
            Text text = slots[i].GetComponentInChildren<Text>();
            text.text = items[i].Name;
        }

    }
}
