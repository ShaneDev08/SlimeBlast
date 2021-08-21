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
    public int selectedWorldIndex;
    [SerializeField] private float transitionSpeed = 3f;
    private Color desiredColour;
    [Header("Selection List")]
    [SerializeField] public List<CharacterSelectionShop> characterSelection = new List<CharacterSelectionShop>();
    [SerializeField] public List<CannonSelectionShop> cannonSelection = new List<CannonSelectionShop>();
    [SerializeField] public List<WorldSelectionShop> worldSelection = new List<WorldSelectionShop>();

     [Header("UI References")]
    [SerializeField] private TextMeshProUGUI characterName;
    [SerializeField] private Image characterSplash;
    [SerializeField] private Image backgroundColour;
    [SerializeField] private TextMeshProUGUI cannonName;
    [SerializeField] private Image cannonSplash;
    [SerializeField] private Image cannonBackgroundColour;
    [SerializeField] private TextMeshProUGUI worldUpgradeName;
    [SerializeField] private Image worldUpgradeSplash;
    [SerializeField] private Image worldUpgradeBackgroundColour;
    [SerializeField] private TextMeshProUGUI worldUpgradeDescription;
    [SerializeField] private TextMeshProUGUI worldUpgrageCost;
    [SerializeField] private GameObject leftSelection;
    [SerializeField] private GameObject leftSelectionCannon;
    [SerializeField] private GameObject leftSelectionWorld;
    [SerializeField] private GameObject rightSelection;
    [SerializeField] private GameObject rightSelectionCannon;
    [SerializeField] private GameObject rightSelectionWorld;
    [SerializeField] private float tweenTime;
    [SerializeField] private TextMeshProUGUI playerMoney;

    

    private void Awake() 
    {
        shopSelection=this;
    }

    public void Start()
    {
        UpdateCannonSelectionUI();
        UpdateCharacterSelectionUI();
        UpdateWorldUpgradeSelectionUI();
    }

    private void Update()
    {
        playerMoney.text = PlayerManager.money.ToString();
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

    public SlimeBall GetCurrentSlimeBall()
    {
       
        return characterSelection[selectedCharacterIndex].slime.GetComponent<SlimeBall>();
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////
    // World Upgrade Screen
    //////////////////////////////////////////////////////////////////////////////////////////////////////////





    public void BuyWorldUpgrade()
    {
       
        PlayerManager.instance.BuyWorldUpgrade(worldSelection[selectedWorldIndex].worldUpgradeId);
    }

    public bool CheckIfWorldUpgradeBeenBought()
    {
        if(PlayerManager.instance.CheckIfWorldUpgradeBought(worldSelection[selectedWorldIndex].worldUpgradeId))
        {
            
            return true;
        }
        else
        {
            return false;
        }
    }


    public void changeWorldUpgradeLeft()
    {
        LeanTween.scale(leftSelectionWorld, Vector3.one * 2, tweenTime).setEasePunch();
        selectedWorldIndex--;
        if (selectedWorldIndex < 0)
            selectedWorldIndex = worldSelection.Count - 1;
        UpdateWorldUpgradeSelectionUI();
    }

    public void changeWorldUpgradeRight()
    {
        LeanTween.scale(rightSelectionWorld, Vector3.one * 2, tweenTime).setEasePunch();
        selectedWorldIndex++;
        if (selectedWorldIndex == worldSelection.Count)
            selectedWorldIndex = 0;
        UpdateWorldUpgradeSelectionUI();
    }

    private void UpdateWorldUpgradeSelectionUI()
    {
        //Character Image Change, Name, Background Colour
        worldUpgradeSplash.sprite = worldSelection[selectedWorldIndex].worldSpriteImage;
        worldUpgradeName.text = worldSelection[selectedWorldIndex].worldSpecialName;
        worldUpgradeDescription.text = worldSelection[selectedWorldIndex].worldSpecialDescription;
        worldSelection[selectedWorldIndex].valueToBuy = PlayerManager.instance.GetCostOfUpgrade(worldSelection[selectedWorldIndex].worldUpgradeId);
        worldUpgrageCost.text = "Value: " + worldSelection[selectedWorldIndex].valueToBuy.ToString();
        //PlayerManager.instance.cannon = cannonSelection[selectedCannonIndex].cannon;

    }
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


[System.Serializable]
public class WorldSelectionShop
{
    public Sprite worldSpriteImage;
    public string worldSpecialName;
    public string worldSpecialDescription;
    public Color worldUpgradeBackGround;
    public int worldUpgradeId;
    public int valueToBuy;
}
