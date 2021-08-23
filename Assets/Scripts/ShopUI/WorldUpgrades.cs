using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldUpgrades
{
    private string nameOfUpgrade;
    private int id;
    private int valueToBuy;
    private bool isBought;


    public string NameOfUpgrade
    {
        get { return nameOfUpgrade; }
        
    }

    public int Id
    {
        get { return id; }
    }

    public int ValueToBuy
    {
        get { return valueToBuy; }
    }

    public bool IsBought
    {
        get { return isBought; }
        set { isBought = value; }
    }


    public WorldUpgrades(string name, int idOfUpgrade,int valueOfUpgrade)
    {
        nameOfUpgrade = name;
        id = idOfUpgrade;
        valueToBuy = valueOfUpgrade;
        isBought = false;
    }



}
