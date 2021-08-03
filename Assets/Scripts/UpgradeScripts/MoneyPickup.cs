using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyPickup : Upgrades
{
    public MoneyPickup(string name, int upgradeAmount, int purchaseAmount, bool enabled)
    {
        this.name = name;
        this.amountOfUpgrades = upgradeAmount;
        this.amountOfUpgrades = 1;
        this.costAmount = purchaseAmount;
        this.isEnabled = enabled;

    }
}
