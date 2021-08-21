using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpgradeScreenManager : MonoBehaviour
{

    public static UpgradeScreenManager instance;

    private SlimeBall currentSlime;
    private CannonSo currentCannon;


    [Header("Ui Elements Slime Upgrade")]
    [SerializeField] private TextMeshProUGUI healthValueText;
    [SerializeField] private TextMeshProUGUI bounceValueText;
    [SerializeField] private TextMeshProUGUI weightValueText;
    [SerializeField] private Button healthButton;
    [SerializeField] private Button bounceButton;
    [SerializeField] private Button weightButton;

    [Header("Ui Elements Cannon Upgrade")]
    [SerializeField] private TextMeshProUGUI powerValueText;
    [SerializeField] private Button powerButton;




    public void BuySlimeUpgrade(int number)
    {
        Debug.Log("Buying Health");
        currentSlime.slimeStats.slimeUpgrade.BuyUpgrade(number);
    }

    public void BuyCannonUpgrade()
    {
        Debug.Log("Buying Power");
        currentCannon.powerUpgrade.BuyUpgrade();
    }

    private void Update()
    {

        CannonUpgradeSettings();
        SlimeUpgradeSettings();





    }

    private void CannonUpgradeSettings()
    {
        currentCannon = ShopSelection.shopSelection.GetCurrentCannonSo();
        powerValueText.text = currentCannon.powerUpgrade.upgradeValue.ToString();

        if(currentCannon.powerUpgrade.currentUpgrade >= currentCannon.powerUpgrade.upgradeAmount)
        {
            powerValueText.text = "MAX";
            powerButton.interactable = false;
        }
    }

    private void SlimeUpgradeSettings()
    {
        currentSlime = ShopSelection.shopSelection.GetCurrentSlimeBall();
        healthValueText.text = currentSlime.slimeStats.slimeUpgrade.costHealthAmount.ToString();
        bounceValueText.text = currentSlime.slimeStats.slimeUpgrade.costBounceAmount.ToString();
        weightValueText.text = currentSlime.slimeStats.slimeUpgrade.costWeighthAmount.ToString();



        if (currentSlime.slimeStats.slimeUpgrade.currentHealthUpgrade >= currentSlime.slimeStats.slimeUpgrade.amountOfHealthUpgrades)
        {
            healthValueText.text = "MAX";
            healthButton.interactable = false;
        }

        if (currentSlime.slimeStats.slimeUpgrade.currentBounceUpgrade >= currentSlime.slimeStats.slimeUpgrade.amountOfBounceUpgrades)
        {
            bounceValueText.text = "MAX";
            bounceButton.interactable = false;
        }

        if (currentSlime.slimeStats.slimeUpgrade.currentWeightUpgrade >= currentSlime.slimeStats.slimeUpgrade.amountOfWeightUpgrades)
        {
            weightValueText.text = "MAX";
            weightButton.interactable = false;
        }
    }
}
