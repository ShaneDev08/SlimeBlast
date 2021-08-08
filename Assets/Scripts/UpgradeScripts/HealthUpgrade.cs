using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class HealthUpgrade : Upgrades
{
    public int extraHealth = 10;


    public HealthUpgrade(string name, int upgradeAmount, int purchaseAmount, int upgradeCost, bool enabled, int upgradeChangeAmountToAdd)
    {
        this.name = name;
        this.amountOfUpgrades = upgradeAmount;
        this.costAmount = purchaseAmount;
        this.upgradeAmount = upgradeCost;
        this.isEnabled = enabled;
        this.upgradeChangeAmount = upgradeChangeAmountToAdd;
    }


    public void UpgradePower(int amount)
    {
        if (CanUpgrade())
        {
            PurchaseUpgrade();
            extraHealth += amount;
        }
    }
}
