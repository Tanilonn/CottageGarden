using System;
using UnityEngine;

[Serializable]
public class Player
{
    public string Name = "test";
    public Vector2 Location = new Vector2(0.5f, 0.5f);
    public int Money = 0;
    public int Exp = 0;
    public Inventory Inventory = new Inventory();
    public Tool SelectedTool;

}
