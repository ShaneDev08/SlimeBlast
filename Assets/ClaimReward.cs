using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClaimReward : MonoBehaviour
{
    public Achievements achievements;

    [Header("Ui")]
    [SerializeField] private Button button;
    [SerializeField] private TextMeshProUGUI moneyText;


    private void Start()
    {
        moneyText.text = "Claim " + achievements.moneyToGive.ToString();
    }

    private void Update()
    {
        
        if (achievements.hasCollected || (achievements.hasCollected && achievements.hasPassed))
        {
            button.interactable = false;
        } 
        else if(achievements.hasPassed)
        {
            button.interactable = true;
        }
        else
        {
            button.interactable = false;
        }

       
    }


    public void RewardClaim()
    {
        achievements.hasCollected = true;
        PlayerManager.money += achievements.moneyToGive;
        
    }
}
