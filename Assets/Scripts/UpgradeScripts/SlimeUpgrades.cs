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
    public int upgradeHealthChangeAmount; // Amount to add to the next upgrade
    [Tooltip("Amount to add to health on next upgrade")]
    public int addToHealthAmount;
    [Tooltip("Amount to add to cost on next upgrade")]
    [SerializeField] private int increaseHealthtCost;

    [Header("SlimeUpgrade|Bounce")]
    [Tooltip("Current Amount of Extra Bounce")]
    public int extraBounce = 0;
    [Tooltip("Amount it can be upgraded")]
    public int amountOfBounceUpgrades;   // How many times can this be upgraded
    [Tooltip("Amount it costs to upgrade")]
    public int costBounceAmount;         // Cost to Upgrade
    [Tooltip("Current amount it has been upgraded")]
    public int currentBounceUpgrade = 0; // How many times has it been upgraded
    [Tooltip("Amount to add for the next upgrade cost")]
    public int upgradeBounceChangeAmount; // Amount to add to the next upgrade
    [Tooltip("Amount to add to Bounce on next upgrade")]
    public int addToBounceAmount;
    [Tooltip("Amount to add to cost on next upgrade")]
    [SerializeField] private int increaseBouncetCost;

    [Header("SlimeUpgrade|Weight")]
    [Tooltip("Current Amount of Extra Weight")]
    public int lessWeight = 0;
    [Tooltip("Amount it can be upgraded")]
    public int amountOfWeightUpgrades;   // How many times can this be upgraded
    [Tooltip("Amount it costs to upgrade")]
    public int costWeighthAmount;         // Cost to Upgrade
    [Tooltip("Current amount it has been upgraded")]
    public int currentWeightUpgrade = 0; // How many times has it been upgraded
    [Tooltip("Amount to add for the next upgrade cost")]
    public int upgradeWeightChangeAmount; // Amount to add to the next upgrade
    [Tooltip("Amount to add to Weight on next upgrade")]
    public int addToWeightAmount;
    [Tooltip("Amount to add to cost on next upgrade")]
    [SerializeField] private int increaseWeightCost;


    private bool CanBuy(int number)
    {
        if(PlayerManager.money >= costHealthAmount && number == 1 && currentHealthUpgrade < amountOfHealthUpgrades)
        {
            return true;
        }
        else if (PlayerManager.money >= costBounceAmount && number == 2 && currentBounceUpgrade < amountOfBounceUpgrades)
        {
            return true;
        }

        else if (PlayerManager.money >= costWeighthAmount && number == 3 && currentWeightUpgrade < amountOfWeightUpgrades)
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
        if(number == 1 && CanBuy(number))
        {
            extraHealth += addToHealthAmount;
            PlayerManager.money -= costHealthAmount;
            costHealthAmount += increaseHealthtCost;
            currentHealthUpgrade += 1;
            addToHealthAmount += 10;
        }

        else if (number == 2 && CanBuy(number))
        {
            extraBounce += addToBounceAmount;
            PlayerManager.money -= costBounceAmount;
            costBounceAmount += increaseBouncetCost;
            currentBounceUpgrade += 1;
            addToBounceAmount += 10;
        }

        else if (number == 3 && CanBuy(number))
        {
            lessWeight += addToWeightAmount;
            PlayerManager.money -= costWeighthAmount;
            costWeighthAmount += increaseWeightCost;
            currentWeightUpgrade += 1;
            addToWeightAmount += 10;
        }
    }

}
