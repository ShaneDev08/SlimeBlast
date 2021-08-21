using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class CannonPowerUpgrade
{
    [Header("Power Upgrade Stats")]
    public int upgradeAmount = 10;
    public int currentUpgrade;
    public int upgradeValue;
    public int powerModifer;
    public int upgradeChangeValue;

    public bool CanBuy()
    {
        if (PlayerManager.money >= upgradeValue  && currentUpgrade < upgradeAmount)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public void BuyUpgrade()
    {
        if (CanBuy())
        {
            powerModifer += upgradeChangeValue;
            PlayerManager.money -= upgradeValue;
            currentUpgrade += 1;
            upgradeValue += upgradeValue;
           
        }
    }

}
