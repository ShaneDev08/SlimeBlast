using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpgrade : Upgrades
{
    public float powerModifier = 10;

    
    public PowerUpgrade(string name, int upgradeAmount, int purchaseAmount, int upgradeCost ,bool enabled, int upgradeChangeAmountToAdd)
    {
        this.name = name;
        this.amountOfUpgrades = upgradeAmount;
        this.costAmount = purchaseAmount;
        this.upgradeAmount = upgradeCost;
        this.isEnabled = enabled;
        this.upgradeChangeAmount = upgradeChangeAmountToAdd;
    }


    public void UpgradePower(float amount)
    {
        if(CanUpgrade())
        {
            PurchaseUpgrade();
            powerModifier += amount;
        }
    }

   

}
