using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    
    private void Update() 
    {
        if (PlayerManager.instance.slimeBall != null)
        {
            this.GetComponent<Button>().interactable = true;
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene("DevScene 1");
    }
}
