using System;
using UnityEngine;

[Serializable]
public class Player
{
    public string Name = "test";
    public Vector2 Location = new Vector2(0.5f, 0.5f);
    public int Exp = 0;
    public Tool SelectedTool;
    public int SelectedSeed;
    public int SelectedItem;

}
