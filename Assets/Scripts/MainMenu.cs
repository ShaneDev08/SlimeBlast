using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private Button playGame;
    private Button settings;
    private Button characterSelection;

    // Start is called before the first frame update
    
    public void PlayGame(){
        SceneManager.LoadScene("CharacterSelection");
    }

    public void OpenSettings(){
        SceneManager.LoadScene("Settings");
    }

    public void OpenCharacterCollection(){
        SceneManager.LoadScene("CharacterCollection");
    }
}
