using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SlimeSelectorController : MonoBehaviour
{
    private int selectedCharacterIndex;
    private Color desiredColour;
    [Header("Character List")]
    [SerializeField] private List<CharacterSelection> characterSelection = new List<CharacterSelection>();

    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI characterName;
    [SerializeField] private Image characterSplash;
    [SerializeField] private Image backgroundColour;

    [Header("Sounds")]
    [SerializeField] private AudioClip nextClick;
    [SerializeField] private AudioClip characterNoise;


    

    private void Start() {
        UpdateCharacterSelectionUI();
    }

    private void UpdateCharacterSelectionUI(){
        //Character Image Change, Name, Background Colour
        characterSplash.sprite =  characterSelection[selectedCharacterIndex].characterSplashImage;
        characterName.text =  characterSelection[selectedCharacterIndex].characterName;
        desiredColour =  characterSelection[selectedCharacterIndex].characterBackgroundColour;
        PlayerManager.instance.slimeBall = characterSelection[selectedCharacterIndex].slime;
    }

    public void changeCharacterLeft(){
        selectedCharacterIndex--;
        if(selectedCharacterIndex < 0)
            selectedCharacterIndex = characterSelection.Count -1;
            UpdateCharacterSelectionUI();
    }
    
    public void changeCharacterRight(){
        selectedCharacterIndex++;
        if(selectedCharacterIndex == characterSelection.Count)
            selectedCharacterIndex = 0;
            UpdateCharacterSelectionUI();
    }

    public void ChangeSceneToGame()
    {
        SceneManager.LoadScene("DevScene 1");
    }

     public void ChangeSceneToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    [System.Serializable]
    public class CharacterSelection{
        public Sprite characterSplashImage;
        public string characterName;
        public Color characterBackgroundColour;
        public GameObject slime;
    }
}
