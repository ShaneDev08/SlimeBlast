using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;
using System.Reflection;
using System;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;


    // Lisdt of Abillitys user can buy
    // 0 Is jump?
    // 1 is?
    // 2 is?
    public static Abillity[] abillities = new Abillity[1];

    
    public static Dictionary<string, Upgrades> shopUpgrades;
    public static int money = 10000;


    public  GameObject slimeBall;
    public GameObject slimeInGame;

    public SlimeScore playerScore;
    private void Awake()
    {
        if(instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        } else if(instance != null)
        {
            Destroy(gameObject);
        }

        AddAllUpgrades();

       playerScore = new SlimeScore();
    }

    

    public void SetSlimeBall(GameObject slime)
    {
        slimeBall = slime;
    }

    // Buy Jump. If money is over 50 then jump abillity has been enabled and added to the list

    public void BuyJump()
    {
        Debug.Log("Bought Jump" + " " + money);
        if (money >= 50)
        {
            money -= 50;
            Debug.Log("Bought Jump" + " money equals " + money);
            JumpAbillity jumpAbillity = new JumpAbillity("Jump", true, 100);
            abillities[0] = jumpAbillity;
        }
    }

   

    private void AddAllUpgrades()
    {
        shopUpgrades = new Dictionary<string, Upgrades>();

        PowerUpgrade cannonPower = new PowerUpgrade("Cannon", 10, 10, 25, false,30);  // Name,  How many upgrades?   Cost to Buy    Cost to upgrade
        shopUpgrades.Add("Cannon", cannonPower);

        HealthUpgrade extraHealth = new HealthUpgrade("Extra Health", 10, 10, 40, false,50);
        shopUpgrades.Add("Extra Health", extraHealth);

        BouncePadsUpgrades bouncePadUpgrade = new BouncePadsUpgrades("BouncePads",1, 5000, false);
        shopUpgrades.Add("BouncePads", bouncePadUpgrade);

        SlimePickUp slimePickUpUpgrade = new SlimePickUp("SlimePickup", 1, 5000, false);
        shopUpgrades.Add("SlimePickup", slimePickUpUpgrade);

        MoneyPickup moneyPickUpUpgrade = new MoneyPickup("MoneyPickup", 1, 5000, false);
        shopUpgrades.Add("MoneyPickup", moneyPickUpUpgrade);

    }


    // Button in the shop UI will need to pass in the parameter string of the upgrade name. 
    // Example for the power upgrade the string Cannon needs to be passed in

    public static bool BuyUpgrade(string name)
    {
        // A check to see if we have enough money to buy the upgrade and if its disabled
        if (money >= shopUpgrades[name].costAmount && !shopUpgrades[name].isEnabled)
        {
            
                shopUpgrades[name].isEnabled = true;
                shopUpgrades[name].currentUpgrade = 1;
                money -= shopUpgrades[name].costAmount;
            return true;

            // Method here to run the UI part of the star and enable the next one??
            // To call a method in the shopUi script do the following:
            // ShopUi.instance.MethodName();
        } 
        // else if the upgrade is enabled we check to see if we have enough money to upgrade
        else if (money >= shopUpgrades[name].upgradeAmount && shopUpgrades[name].isEnabled)
        {
            UpgradeBoughtUpgrade(name);
            return true;
        }
        return false;
    }

    public static void UpgradeBoughtUpgrade(string name)
    {
        if (shopUpgrades[name].isEnabled && shopUpgrades[name].currentUpgrade <= shopUpgrades[name].amountOfUpgrades)
        {
            if(shopUpgrades[name].GetType().ToString() == "PowerUpgrade")
            {

                money -= shopUpgrades[name].upgradeAmount;
                PowerUpgrade power = (PowerUpgrade)PlayerManager.shopUpgrades[name];
                power.UpgradePower(2);
                shopUpgrades[name] = power;
            }
           else  if (shopUpgrades[name].GetType().ToString() == "HealthUpgrade")
            {

                money -= shopUpgrades[name].upgradeAmount;
                HealthUpgrade power = (HealthUpgrade)PlayerManager.shopUpgrades[name];
                power.UpgradePower(10);
                shopUpgrades[name] = power;

            }

        }


    }


    //public void AddToPlayerScoreHeight(int amount)
    //{
    //    playerScore.DistanceInHeight = amount;
    //}
    //public void AddToPlayerScoreDistance(int amount)
    //{
    //    playerScore.DistanceTraveled = amount;
    //}

    public void OnRoundOver()
    {
        playerScore.ResetScores();
    }

    // Dynamically Create a class wtih String

    //string className = shopUpgrades[name].GetType().ToString();
    //var myType = typeof(PlayerManager);
    //var n = myType.Namespace;

    //dynamic myObj = Activator.CreateInstance(Type.GetType(n + "." + className), false);
    //myObj =  shopUpgrades[name];
    //            myObj.UpgradePower(2);
}
