using System;

public class Item
{
    protected Item(int id, string name, int buy, int sell) { ID = id; Name = name; BuyPrice = buy; SellPrice = sell; }
    public int ID { get; }
    public string Name { get; }
    public int BuyPrice { get; }
    public int SellPrice { get; }
    public override string ToString() => Name;
}
