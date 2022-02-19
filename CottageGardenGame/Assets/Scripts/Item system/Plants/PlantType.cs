using System.Collections.Generic;

public class PlantType : Plant
{
    protected PlantType(int id, string name, int period) : base(id, name, period)
    {
    }

    public static readonly PlantType Carrot = new PlantType(0, "carrot", 1);
    public static readonly PlantType Beet = new PlantType(1, "beet", 2);

    public static List<PlantType> types = new List<PlantType>()
    {
        Carrot,
        Beet,
    };

}