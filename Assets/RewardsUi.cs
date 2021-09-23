using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RewardsUi : MonoBehaviour
{

    [Header("UI Elements")]
    [SerializeField] private GameObject rewardTemplate;
    [SerializeField] private GameObject templateHolder;
    [SerializeField] private TextMeshProUGUI slimeCoins;


    private static AchievementListSO achievements;


    private void Start()
    {
        achievements = Instantiate(Resources.Load("AchievementList", typeof(AchievementListSO)) as AchievementListSO);

        CreateUI();
    }

    private void Update()
    {
        slimeCoins.text = "SlimeCoins: " + PlayerManager.money.ToString();
    }

    private void CreateUI()
    {
        for(int i = 0; i < achievements.achievementList.Count;i++)
        {
           GameObject template = Instantiate(rewardTemplate);
            template.transform.SetParent(templateHolder.gameObject.transform);
            template.gameObject.transform.Find("AchievementName").GetComponent<TextMeshProUGUI>().text = achievements.achievementList[i].nameOfAchievement;
            template.GetComponent<ClaimReward>().achievements = achievements.achievementList[i];
            
        }
    }
}
