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
    [SerializeField] Button startButton;
    [SerializeField] Image powerImage;

    [Header("PlayerScore")]
    [SerializeField] TextMeshProUGUI scoreText;

    public float powerAmount;




    // Makes this a singleton using instance as the var
    private void Awake()
    {
        instance = this;
    }
    //[SerializeField] Button fireButton;
    void Start()
    {
        
    }

    // Update is called once per frame
   public void UpdateScoreText(int score)
    {
        scoreText.text = "Score: " +  score.ToString();
    }
}
