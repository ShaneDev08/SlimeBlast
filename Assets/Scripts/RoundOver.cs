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

    public void updateText()
    {
        scoreText.text = "Score: " + " ";
        distanceTravelledText.text = "Distance Travelled: " + "";
        obstaclesHitText.text = "Obstacles Hit: " + " ";
        moneyEarntText.text = "Money: " + "";
        heightText.text = "Height: " + "";
        slimeCollectedText.text = "Slime Collected: " + "";
    }

    public void HomeScreen(){
        SceneManager.LoadScene("MainMenu");
    }
    public void RetryButton(){
        SceneManager.LoadScene("DevScene 1");
    }

    public void ShopScreen(){
        SceneManager.LoadScene("Shop");
    }

}
