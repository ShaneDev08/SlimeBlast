using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SlimeUpgrades
{


    // Id  1 is Health   2 is Bounce   3 is    4 is

    [Header("SlimeUpgrade|Health")]
    [Tooltip("Current Amount of Extra Health")]
    public int extraHealth = 0;
    [Tooltip("Amount it can be upgraded")]
    public int amountOfHealthUpgrades;   // How many times can this be upgraded
    [Tooltip("Amount it costs to upgrade")]
    public int costHealthAmount;         // Cost to Upgrade
    [Tooltip("Current amount it has been upgraded")]
    public int currentHealthUpgrade = 0; // How many times has it been upgraded
    [Tooltip("Amount to add for the next upgrade cost")]
    public int upgradeChangeAmount; // Amount to add to the next upgrade
    [Tooltip("Amount to add to health on next upgrade")]
    public int addToHealthAmount;

    [Header("SlimeUpgrade|Bounce")]
    [Tooltip("Current Amount of Extra Bounce")]
    public int extraBounce = 0;
    [Tooltip("Amount it can be upgraded")]
    public int amountOfBouncehUpgrades;   // How many times can this be upgraded
    [Tooltip("Amount it costs to upgrade")]
    public int costBouncehAmount;         // Cost to Upgrade
    [Tooltip("Current amount it has been upgraded")]
    public int currentBounceUpgrade = 0; // How many times has it been upgraded
    [Tooltip("Amount to add for the next upgrade cost")]
    public int upgradeBounceChangeAmount; // Amount to add to the next upgrade
    [Tooltip("Amount to add to Bounce on next upgrade")]
    public int addToBounceAmount;


    private bool CanBuy(int number)
    {
        if(PlayerManager.money >= costHealthAmount && number == 1 && currentHealthUpgrade < amountOfHealthUpgrades)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void BuyUpgrade(int number)
    {
        if(CanBuy(number))
        {
            extraHealth += addToHealthAmount;
            PlayerManager.money -= costHealthAmount;
            currentHealthUpgrade += 1;
            addToHealthAmount += 10;
        }
    }

}
