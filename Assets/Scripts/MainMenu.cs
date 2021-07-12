using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public Button playGame;
    public Button settings;
    public Button characterSelection;

    // Start is called before the first frame update
    
    public void PlayGame(){
        SceneManager.LoadScene("DevScene 1");
    }

    public void OpenSettings(){
        SceneManager.LoadScene("Settings");
    }

    public void OpenCharacterSelection(){
        SceneManager.LoadScene("CharacterSelection");
    }
}
