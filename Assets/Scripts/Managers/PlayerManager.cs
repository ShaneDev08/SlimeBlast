using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;
using System.Reflection;
using System;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using GooglePlayGames.BasicApi.SavedGame;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[Serializable]
public class PlayerManager : MonoBehaviour
{

    // Google Api saving variables
    private bool isSaving;


    public static PlayerManager instance;


    public List<WorldUpgrades> upgradeForWorld;

    

    public static float money = 10000;


    public  GameObject slimeBall;
    public GameObject slimeInGame;

    public GameObject cannon;

    public SlimeScore playerScore;


    private static bool hasLoaded = false;

    [System.NonSerialized]
    private static AchievementListSO achievements;
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

        if (!hasLoaded)
        {
            //AddAllUpgrades();
        }

       playerScore = new SlimeScore();

        
        
      
            
       // Debug.Log(achievements);
    }

    private void Start()
    {
        upgradeForWorld = new List<WorldUpgrades>();
        //OpenSaveGame(false);
        // Load the achievement scritableobject
        achievements = Instantiate(Resources.Load("AchievementList", typeof(AchievementListSO)) as AchievementListSO);
        AddAllWorldUpgrades();
        
    }

    private void Update()
    {
        
        CheckAchievements();
  
    }

    private void CheckAchievements()
    {
        for (int i = 0; i < achievements.achievementList.Count; i++)
        {
            if (achievements.achievementList[i].nameOfAchievement == "100m Distance" && playerScore.DistanceTraveled > achievements.achievementList[i].amountToScore && !achievements.achievementList[i].hasPassed)
            {
                achievements.achievementList[i].hasPassed = true;
                Social.ReportProgress("CgkI-p3e1-gWEAIQBA", 100f, (bool success) => {
                
             });
                PlayerManager.money += 500;
                Debug.Log("Achievement Passed!");
                
            }
        }
    }




    public void SetSlimeBall(GameObject slime)
    {
        slimeBall = slime;
    }

    // Buy Jump. If money is over 50 then jump abillity has been enabled and added to the list


// 0 bouncepad
// 1 jetpack
// 2 fan
// 3 slimeSpawner


   private void AddAllWorldUpgrades()
    {
        WorldUpgrades bouncePadUpgrade = new WorldUpgrades("BouncePad", 0, 5000);
        WorldUpgrades jetPack = new WorldUpgrades("JetPack", 1, 6000);
        WorldUpgrades fan = new WorldUpgrades("Fan", 2, 1000);
        WorldUpgrades slimeSpawner = new WorldUpgrades("SlimeSpawner", 3, 10000);

        upgradeForWorld.Add(bouncePadUpgrade);
        upgradeForWorld.Add(jetPack);
        upgradeForWorld.Add(fan);
        upgradeForWorld.Add(slimeSpawner);
    }

    public bool CheckIfWorldUpgradeBought (int id)
    {
        
        foreach (WorldUpgrades upgrades in upgradeForWorld)
        {
            
            if(upgrades.Id == id && upgrades.IsBought)
            {
               
                return true;
            }   
        }
        return false;

       
    }

    public void BuyWorldUpgrade(int id)
    {
        
        foreach(WorldUpgrades upgrade in upgradeForWorld)
        {
            if(upgrade.Id == id && money >= upgrade.ValueToBuy)
            {
                upgrade.IsBought = true;
                money -= upgrade.ValueToBuy;
                
            }
        }
    }

    public int GetCostOfUpgrade(int id)
    {
        foreach (WorldUpgrades upgrade in upgradeForWorld)
        {
            if (upgrade.Id == id)
            {
                return upgrade.ValueToBuy;

            }
        }
        return 0;
    }

  
   

   

    public void OnRoundOver()
    {
        playerScore.ResetScores();
    }

    

}



























// Dynamically Create a class wtih String

//string className = shopUpgrades[name].GetType().ToString();
//var myType = typeof(PlayerManager);
//var n = myType.Namespace;

//dynamic myObj = Activator.CreateInstance(Type.GetType(n + "." + className), false);
//myObj =  shopUpgrades[name];
//            myObj.UpgradePower(2);





//private string GetSaveString()
// {
//BinaryFormatter formatter = new BinaryFormatter();
//var mStream = new MemoryStream();
//try
//{

//    formatter.Serialize(mStream, shopUpgrades);
//    Debug.Log("Hello" + mStream.ToArray() + "|" + mStream.ToString()); 
//}
//catch(Exception e)
//{
//    Debug.Log(e);
//}


// return money.ToString();
//  }

//private void LoadSaveString(string loadedData)
// {
//MemoryStream memStream = new MemoryStream();
//BinaryFormatter binForm = new BinaryFormatter();
//memStream.Write(loadedData, 0, loadedData.Length);
//memStream.Seek(0, SeekOrigin.Begin);
//Dictionary<string,Upgrades> obj = (Dictionary<string, Upgrades>)binForm.Deserialize(memStream);
//Debug.Log(obj.ToString());
//shopUpgrades = obj;

//  money = Int32.Parse(loadedData);
// }




//public void OpenSaveGame(bool saving)
//{
//   Debug.Log("Open Save");

//   if(Social.localUser.authenticated)
//  {
//  isSaving = saving;
// ((PlayGamesPlatform)Social.Active).SavedGame.OpenWithAutomaticConflictResolution("SlimeBlast", GooglePlayGames.BasicApi.DataSource.ReadCacheOrNetwork, ConflictResolutionStrategy.UseLongestPlaytime, SaveGameOpened); // Will call SaveGameOpened Method as a call back.
// }
// }

// private void SaveGameOpened(SavedGameRequestStatus status, ISavedGameMetadata meta)
// {
//  if(status == SavedGameRequestStatus.Success)
//   {
//       if(isSaving) // Writing
//      {
//        byte[] data = System.Text.ASCIIEncoding.ASCII.GetBytes(GetSaveString()); // Need to get the string and convert to bytes or maybe just pass in the bytes
//       SavedGameMetadataUpdate update = new SavedGameMetadataUpdate.Builder().WithUpdatedDescription("Saved At " + DateTime.Now.ToString()).Build();

//      ((PlayGamesPlatform)Social.Active).SavedGame.CommitUpdate(meta, update, data, SaveUpdate);
// }
// else // Reading
// {
//    ((PlayGamesPlatform)Social.Active).SavedGame.ReadBinaryData(meta, SaveRead);
// }
// }
// }

// Load
// private void SaveRead(SavedGameRequestStatus status, byte[] data)
// {
//    if(status == SavedGameRequestStatus.Success)
//    {

//      string saveData = System.Text.ASCIIEncoding.ASCII.GetString(data);
//        LoadSaveString(saveData);
//       Debug.Log(saveData);

//  }
//  }


// Success save
//  private void SaveUpdate(SavedGameRequestStatus status, ISavedGameMetadata meta)
//  {
//     Debug.Log(status);
//  }














//private void AddAllUpgrades()
//{
//    shopUpgrades = new Dictionary<string, Upgrades>();

//    PowerUpgrade cannonPower = new PowerUpgrade("Cannon", 10, 10, 25, false,30);  // Name,  How many upgrades?   Cost to Buy    Cost to upgrade
//    shopUpgrades.Add("Cannon", cannonPower);

//    HealthUpgrade extraHealth = new HealthUpgrade("Extra Health", 10, 10, 40, false,50);
//    shopUpgrades.Add("Extra Health", extraHealth);

//    BouncePadsUpgrades bouncePadUpgrade = new BouncePadsUpgrades("BouncePads",1, 5000, false);
//    shopUpgrades.Add("BouncePads", bouncePadUpgrade);

//    SlimePickUp slimePickUpUpgrade = new SlimePickUp("SlimePickup", 1, 5000, false);
//    shopUpgrades.Add("SlimePickup", slimePickUpUpgrade);

//    MoneyPickup moneyPickUpUpgrade = new MoneyPickup("MoneyPickup", 1, 5000, false);
//    shopUpgrades.Add("MoneyPickup", moneyPickUpUpgrade);


//    hasLoaded = true;
//}


// Button in the shop UI will need to pass in the parameter string of the upgrade name. 
// Example for the power upgrade the string Cannon needs to be passed in

//public static bool BuyUpgrade(string name)
//{
//    // A check to see if we have enough money to buy the upgrade and if its disabled
//    if (money >= shopUpgrades[name].costAmount && !shopUpgrades[name].isEnabled)
//    {

//            shopUpgrades[name].isEnabled = true;
//            shopUpgrades[name].currentUpgrade = 1;
//            money -= shopUpgrades[name].costAmount;
//        return true;

//        // Method here to run the UI part of the star and enable the next one??
//        // To call a method in the shopUi script do the following:
//        // ShopUi.instance.MethodName();
//    } 
//    // else if the upgrade is enabled we check to see if we have enough money to upgrade
//    else if (money >= shopUpgrades[name].upgradeAmount && shopUpgrades[name].isEnabled)
//    {
//        UpgradeBoughtUpgrade(name);
//        return true;
//    }
//    return false;
//}

//public static void UpgradeBoughtUpgrade(string name)
//{
//    if (shopUpgrades[name].isEnabled && shopUpgrades[name].currentUpgrade <= shopUpgrades[name].amountOfUpgrades)
//    {
//        if(shopUpgrades[name].GetType().ToString() == "PowerUpgrade")
//        {

//            money -= shopUpgrades[name].upgradeAmount;
//            PowerUpgrade power = (PowerUpgrade)PlayerManager.shopUpgrades[name];
//            power.UpgradePower(2);
//            shopUpgrades[name] = power;
//        }
//       else  if (shopUpgrades[name].GetType().ToString() == "HealthUpgrade")
//        {

//            money -= shopUpgrades[name].upgradeAmount;
//            HealthUpgrade power = (HealthUpgrade)PlayerManager.shopUpgrades[name];
//            power.UpgradePower(10);
//            shopUpgrades[name] = power;

//        }

//    }


//}


//public void AddToPlayerScoreHeight(int amount)
//{
//    playerScore.DistanceInHeight = amount;
//}
//public void AddToPlayerScoreDistance(int amount)
//{
//    playerScore.DistanceTraveled = amount;
//}