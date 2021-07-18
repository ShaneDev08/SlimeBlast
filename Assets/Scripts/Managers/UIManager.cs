using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{

    // Make this script a singleton
    public static UIManager instance;


    [Header("FireFunction")]
    [SerializeField] public Button startButton;
    [SerializeField] Image powerImage;

    [Header("PlayerScore")]
    [SerializeField] TextMeshProUGUI scoreText;

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
        roundOverUI.SetActive(false);
    }

    public void disableGameUI()
    {
        gameUI.SetActive(false);
    }

    public void EnableRoundOverUI()
    {
        roundOverUI.SetActive(true);
    }

    
   public void UpdateScoreText(int score)
    {
        scoreText.text = "Score: " +  score.ToString();
    }
}
