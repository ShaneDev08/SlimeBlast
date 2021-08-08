using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class RoundOver : MonoBehaviour
{

    public Transform roundUIPanel;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI distanceTravelledText;
    public TextMeshProUGUI obstaclesHitText;
    public TextMeshProUGUI moneyEarntText;
    public TextMeshProUGUI heightText;
    public TextMeshProUGUI slimeCollectedText;
    
    Slime slime;
    public void Start()
    {
        roundUIPanel.localPosition = new Vector2(0, -Screen.height);
        slime = GetComponent<Slime>();
    }

    private void Update()
    {
        UpdateText();
    }

    public void UpdateText()
    {
        scoreText.text = "Score:" + PlayerManager.instance.playerScore.Score.ToString();
        heightText.text = "Max Height:" + PlayerManager.instance.playerScore.DistanceInHeight.ToString();  // MAX Height
        distanceTravelledText.text = "Max Distance:" + PlayerManager.instance.playerScore.DistanceTraveled.ToString(); // MAX Distance Travelled
        moneyEarntText.text = "Money Collected:" + PlayerManager.instance.playerScore.MoneyCollected;
        slimeCollectedText.text = "Slime Collected:" + PlayerManager.instance.playerScore.SlimeCollected;
        obstaclesHitText.text = "Obstacles Hit:" + PlayerManager.instance.playerScore.obstaclesHit.ToString();;
    }

    public void HomeScreen(){
        ResetScores();
        PlayerManager.instance.OpenSaveGame(true);
        SceneManager.LoadScene("MainMenu");
    }
    public void RetryButton(){
        ResetScores();
        SceneManager.LoadScene("DevScene 1");
    }

    public void ShopScreen(){
        ResetScores();
        SceneManager.LoadScene("Shop");
    }

    private void ResetScores()
    {
        PlayerManager.instance.OnRoundOver();
    }

}
