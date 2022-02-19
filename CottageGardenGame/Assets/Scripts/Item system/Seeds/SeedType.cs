using System.Collections.Generic;

public class SeedType : Seed
{
    protected SeedType(int id, string name, int buy, int sell) : base(id, name, buy, sell)
    {
    }

    public static readonly SeedType Carrot = new SeedType(0, "carrot", 10, 5);
    public static readonly SeedType Beet = new SeedType(1, "beet", 20, 15);

    public static List<SeedType> types = new List<SeedType>()
    {
        Carrot,
        Beet,
    };
   
}