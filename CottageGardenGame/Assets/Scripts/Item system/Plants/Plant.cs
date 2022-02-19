using System;

public class Plant
{
    protected Plant(int id, string name, int period) { ID = id; Name = name; GrowPeriod = period; }
    public int ID { get; }
    public string Name { get; }
    public int GrowPeriod { get; }
    public override string ToString() => Name;
}
