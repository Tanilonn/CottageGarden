using System.Collections.Generic;

public class ItemType : Seed
{
    protected ItemType(int id, string name, int buy, int sell) : base(id, name, buy, sell)
    {
    }

    //reserved spots 1-1000
    public static readonly ItemType Carrot = new ItemType(0, "carrot", 10, 5);
    public static readonly ItemType Beet = new ItemType(1, "beet", 20, 15);

    //reserved spots 1000-2000
    public static readonly ItemType Light = new ItemType(1000, "light", 10, 5);

    public static List<ItemType> types = new List<ItemType>()
    {
        Carrot,
        Beet,
        Light
    };


}