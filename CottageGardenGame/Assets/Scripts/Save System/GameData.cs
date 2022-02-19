using System;
using UnityEngine;

[Serializable]
public class GameData
{
    public Player Player = new Player();
    public Inventory Inventory = new Inventory();
    public World World = new World();
    //PLAYER
    /*
     * location
     * inventory
     * money
     * name
     * exp
     */

    //WORLD
    /*
     * tiles
     * plants
     * decorations
     * animals
     */

    //FOR EACH ANIMAL
    /*
     * location
     * name
     * stats
     * status
     */

    //FOR EACH PLANT
    /*
     * location
     * name
     * stats
     * status
     */


}
