using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopSelection : MonoBehaviour
{
    public static ShopSelection shopSelection;
    public int selectedCharacterIndex;
    public int selectedCannonIndex;
    [SerializeField] private float transitionSpeed = 3f;
    private Color desiredColour;
    [Header("Selection List")]
    [SerializeField] public List<CharacterSelectionShop> characterSelection = new List<CharacterSelectionShop>();
    [SerializeField] public List<CannonSelectionShop> cannonSelection = new List<CannonSelectionShop>();

     [Header("UI References")]
    [SerializeField] private TextMeshProUGUI characterName;
    [SerializeField] private Image characterSplash;
    [SerializeField] private Image backgroundColour;
    [SerializeField] private TextMeshProUGUI cannonName;
    [SerializeField] private Image cannonSplash;
    [SerializeField] private Image cannonBackgroundColour;
    [SerializeField] private GameObject leftSelection;
    [SerializeField] private GameObject leftSelectionCannon;
    [SerializeField] private GameObject rightSelection;
    [SerializeField] private GameObject rightSelectionCannon;
    [SerializeField] private float tweenTime;


    private void Awake() 
    {
        shopSelection=this;
    }
    private void UpdateCharacterSelectionUI()
    {
        //Character Image Change, Name, Background Colour
        characterSplash.sprite =  characterSelection[selectedCharacterIndex].characterSplashImage;
        characterName.text =  characterSelection[selectedCharacterIndex].characterName.ToString();
        desiredColour =  characterSelection[selectedCharacterIndex].characterBackgroundColour;
       // PlayerManager.instance.slimeBall = characterSelection[selectedCharacterIndex].slime;
    }

    public void changeCharacterLeft()
    {
        LeanTween.scale(leftSelection, Vector3.one * 2, tweenTime).setEasePunch();
        selectedCharacterIndex--;
        if(selectedCharacterIndex < 0)
            selectedCharacterIndex = characterSelection.Count -1;
            UpdateCharacterSelectionUI();
    }
    
    public void changeCharacterRight()
    {
        LeanTween.scale(rightSelection, Vector3.one * 2, tweenTime).setEasePunch();
        selectedCharacterIndex++;
        if(selectedCharacterIndex == characterSelection.Count)
            selectedCharacterIndex = 0;
            UpdateCharacterSelectionUI();
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

    private void UpdateCannonSelectionUI()
    {
        //Character Image Change, Name, Background Colour
        cannonSplash.sprite =  cannonSelection[selectedCannonIndex].cannonSplashImage;
        cannonName.text =  cannonSelection[selectedCannonIndex].cannonName.ToString();
        //PlayerManager.instance.cannon = cannonSelection[selectedCannonIndex].cannon;
  
    }

    public void changeCannonLeft()
    {
        LeanTween.scale(leftSelectionCannon, Vector3.one * 2, tweenTime).setEasePunch();
        selectedCannonIndex--;
        if(selectedCannonIndex < 0)
            selectedCannonIndex = cannonSelection.Count -1;
            UpdateCannonSelectionUI();
    }
    
    public void changeCannonRight()
    {
        LeanTween.scale(rightSelectionCannon, Vector3.one * 2, tweenTime).setEasePunch();
        selectedCannonIndex++;
        if(selectedCannonIndex == cannonSelection.Count)
            selectedCannonIndex = 0;
            UpdateCannonSelectionUI();
    }

    public bool CheckIfSlimeBought()
    {
        if (characterSelection[selectedCharacterIndex].slime.GetComponent<SlimeBall>().slimeStats.slimeBought.isUnlocked)
        {
            return true;
        } 
        else
            return false;
    }

     public bool CheckIfCannonBought()
    {
        if (cannonSelection[selectedCannonIndex].cannon.GetComponent<Launcher>().cannonStats.isBought)
        {
            return true;
        } 
        else
            return false;
    }

    public void BuyingSlime()
    {
        characterSelection[selectedCharacterIndex].slime.GetComponent<SlimeBall>().slimeStats.slimeBought.isUnlocked = true;
    }

    public void BuyingCannon()
    {
        cannonSelection[selectedCannonIndex].cannon.GetComponent<Launcher>().cannonStats.isBought = true;
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////
}

 [System.Serializable]
    public class CharacterSelectionShop{
        public Sprite characterSplashImage;
        public string characterName;
        public Color characterBackgroundColour;
        public GameObject slime;
    }

    [System.Serializable]
    public class CannonSelectionShop
    {
        public Sprite cannonSplashImage;
        public string cannonName;
        public Color cannonBackgroundColour;
        public GameObject cannon;
    }