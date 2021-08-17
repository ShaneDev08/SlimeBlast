using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpgradeScreenManager : MonoBehaviour
{

    public static UpgradeScreenManager instance;

    private SlimeBall currentSlime;


    [Header("Ui Elements")]
    [SerializeField] private TextMeshProUGUI healthValueText;
    [SerializeField] private TextMeshProUGUI bounceValueText;
    [SerializeField] private TextMeshProUGUI weightValueText;
    [SerializeField] private Button healthButton;
    [SerializeField] private Button bounceButton;
    [SerializeField] private Button weightButton;



    public void BuyUpgrade(int number)
    {
        Debug.Log("Buying Health");
        currentSlime.slimeStats.slimeUpgrade.BuyUpgrade(number);
    }

    private void Update()
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
