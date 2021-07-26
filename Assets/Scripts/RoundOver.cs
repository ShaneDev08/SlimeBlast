using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoundOver : MonoBehaviour
{

    public Transform roundUIPanel;
    
    public void Start()
    {
        roundUIPanel.localPosition = new Vector2(0, -Screen.height);
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
