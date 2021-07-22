using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;



public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;


    // Lisdt of Abillitys user can buy
    // 0 Is jump?
    // 1 is?
    // 2 is?
    public static Abillity[] abillities = new Abillity[1];

    
    public static Dictionary<string, Upgrades> shopUpgrades;
    public static int money = 100;


    public  GameObject slimeBall;
    public GameObject slimeInGame;
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

    private void Update()
    {
        
    }

    private void AddAllUpgrades()
    {
        PowerUpgrade cannonPower = new PowerUpgrade("Power", 10, 10, 10, false);
        cannonPower.UpgradePower(30);
        shopUpgrades = new Dictionary<string, Upgrades>();

        shopUpgrades.Add("Cannon", cannonPower);
    }


    public static void BuyCannonUpgrade()
    {
        if (money >= shopUpgrades["Cannon"].costAmount)
        {
            shopUpgrades["Cannon"].isEnabled = true;
            Debug.Log(shopUpgrades["Cannon"].isEnabled);
            money -= shopUpgrades["Cannon"].costAmount;
        }
    }

      
}
