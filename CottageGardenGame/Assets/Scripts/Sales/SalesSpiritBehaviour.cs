using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SalesSpiritBehaviour : MonoBehaviour
{
    public InventoryBehaviour PlayerInventory;

    public Button OpenButton;
    public GameObject Shelve;
    public Button ItemSlot;

    private bool IsOpen;
    private bool RoutineRunning;
    private List<Button> playerStock = new List<Button>();

    private void Awake()
    {
        DisplayStock();
        DisplayPlayerStock();

        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager.SalesSpiritEvent += GameManager_SalesSpiritEvent;
        OpenButton.gameObject.SetActive(false);

    }

    private void GameManager_SalesSpiritEvent(object sender, System.EventArgs e)
    {
        Debug.Log("event sub");
        if(!RoutineRunning) StartCoroutine(WalkInCoroutine());

    }

    public IEnumerator WalkInCoroutine()
    {
        //start walking in, can already click
        RoutineRunning = true;
        OpenButton.gameObject.SetActive(true);

        while (IsOpen) yield return null; 
        yield return new WaitForSeconds(5);
        while (IsOpen) yield return null;

        //start walking away, can't click anymore
        OpenButton.gameObject.SetActive(false);
        RoutineRunning = false;
    }

    public void OpenInventory()
    {
        RefreshPlayerStock();
        IsOpen = true;
    }

    public void CloseInventory()
    {
        IsOpen = false;

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
