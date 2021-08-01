using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades
{

    public string name;
    public int amountOfUpgrades;   // How many times can this be upgraded
    public int costAmount;         // Cost to Buy
    public int upgradeAmount;      // Cost to upgrade
    public int currentUpgrade = 0; // How many times has it been upgraded
    public bool isEnabled = false;
    public int upgradeChangeAmount; // Amount to add to the next upgrade


    //public Upgrades(string name,int upgradeAmount, int purchaseAmount,int upgradeCost)
    //{
    //    this.name = name;
    //    this.amountOfUpgrades = upgradeAmount;
    //    this.costAmount = purchaseAmount;
    //    this.upgradeAmount = upgradeCost;
    //}

    // Check to see if it can be upgraded even more
    public bool CanUpgrade()
    {
        if(currentUpgrade == amountOfUpgrades)
        {
            return false;
        } 
        else
        {
            return true;
        }
    }

    // Add to the upgrade amount and add an extra amount to the upgrade cost

    public void PurchaseUpgrade()
    {
        currentUpgrade++;
        upgradeAmount += upgradeChangeAmount;
    }
   
}
