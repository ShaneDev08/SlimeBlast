using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class UIManager : MonoBehaviour
{

    // Make this script a singleton
    public static UIManager instance;


    [Header("FireFunction")]
    [SerializeField] private Button fireButton;
    [SerializeField] Image powerImage;

    [Header("PlayerScore")]
    [SerializeField] TextMeshProUGUI scoreText;

    //[Header("Slime Score Text References")]
    //public TextMeshProUGUI distanceScoreText;
    //public TextMeshProUGUI heightText;
    //public TextMeshProUGUI moneyCollectedText;
    //public TextMeshProUGUI slimeCollectedText;

    public float powerAmount;

    public GameObject roundOverUI;
    public GameObject gameUI;




    // Makes this a singleton using instance as the var
    private void Awake()
    {
        instance = this;
    }
    
    void Start()
    {
        //roundOverUI.SetActive(false);
    }

    private void Update()
    {
        //UpdateStats();
    }

    public void disableGameUI()
    {
        gameUI.SetActive(false);
    }

    public void EnableRoundOverUI()
    {
         
        roundOverUI.LeanMoveLocalY(0, 0.5f).setEaseOutExpo();//roundOverUI.SetActive(true);
    }

    public void DisableRoundOverUI()
    {
        roundOverUI.LeanMoveLocalY(-1000, 0.5f).setEaseOutExpo();//roundOverUI.SetActive(true);
    }

    
   public void UpdateScoreText(int score)
    {
        scoreText.text = "Score: " +  score.ToString();
    }

    public void DisableFireButton()
    {
        fireButton.enabled = false;
        fireButton.GetComponent<EventTrigger>().enabled = false;
        fireButton.gameObject.SetActive(false);
        powerImage.gameObject.SetActive(false);
       
    }

    //private void UpdateStats()
    //{
    //    heightText.text = "Max Height:" + PlayerManager.instance.playerScore.DistanceInHeight.ToString();  // MAX Height
    //    distanceScoreText.text = "Max Distance:" + PlayerManager.instance.playerScore.DistanceTraveled.ToString(); // MAX Distance Travelled
    //    moneyCollectedText.text = "Money Collected:" + PlayerManager.instance.playerScore.MoneyCollected;
    //    slimeCollectedText.text = "Slime Collected:" + PlayerManager.instance.playerScore.SlimeCollected;
    //}
}
