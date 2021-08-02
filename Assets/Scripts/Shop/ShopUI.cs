using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ShopUI : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("UI References")]
    public GameObject cannonUpgradeButton;
    public GameObject slimeUpgradeButton;
    public GameObject worldUpgradeButton;
    public AudioClip onButtonClick;
    public AudioSource audio;
    public float volume;
    public Transform cannonUpgradeContainer;
    public CanvasGroup backgroundCannon;
    public Transform slimeUpgradeContainer;
    public CanvasGroup backgroundSlime;
    public Transform worldUpgradeContainer;
    public TextMeshProUGUI cannonCost;
    public GameObject cannonBuyButton;
    [Tooltip("List of Texts for stars for the cost of buying or upgrading")]
    public TextMeshProUGUI[] upgradeValueText;      // 0 is Cannon Upgrade  1 is Extra Health Upgrade
    public GameObject star;
   // public GameObject grid;
    // 0 worldUpgrade
    //1 
    public CanvasGroup backgroundWorld;
    public TextMeshProUGUI moneyText;
    [Header("ObjectReferences")]
    PlayerManager playerManager;
    Upgrades upgradeManager;
    [Header("TweenValues")]
    [SerializeField] private float tweenTime;
    [Tooltip("List of Grids for stars under Cannon Upgrade")]
    public GridLayoutGroup[] cannonGrids;       // 0 is Cannon Power 
    [Tooltip("List of Grids for stars under Slime Upgrade")]
    public GridLayoutGroup[] slimeGrids;        // 0 is Extra Health
    [Tooltip("List of Grids for stars under World Upgrade")]
    public GridLayoutGroup[] worldGrids;



    //public List<GameObject> stars;
    public Dictionary<string, List<GameObject>> stars2;
    private List<Upgrades> listOfUpgrades;
    


    public static ShopUI instance;

    private Color fullColor;
    private Color fadedColor;
    private List<GameObject> list;



    public void Start()
    {

        GenerateLists();
        StarColors();
        AddUpgradeList();
        AddStarsToGui();
        
        instance = this;
        audio = GameObject.Find("ShopCanvas").GetComponent<AudioSource>();
        playerManager = GetComponent<PlayerManager>();

        
        CheckForStarsBought();
        InvokeRepeating("StarReadyAnim", 3, 3);


    }

    private void Update() {
        updateMoneyValue();
        UpdateUpgradeText();

    }

    private void GenerateLists()
    {
        stars2 = new Dictionary<string, List<GameObject>>();
        list = new List<GameObject>();
        listOfUpgrades = new List<Upgrades>();
    }

    public void onClickCannonUpgrade()
    {
        PlayButtonClick();
        LeanTween.scale(cannonUpgradeButton, Vector3.one * 2, tweenTime).setEasePunch();
        CannonMoveContainer();
        slimeUpgradeContainer.LeanMoveLocalY(-Screen.height,tweenTime);
        worldUpgradeContainer.LeanMoveLocalY(-Screen.height,tweenTime);
    }

    public void onClickSlimeUpgrade()
    {
        PlayButtonClick();
        LeanTween.scale(slimeUpgradeButton, Vector3.one * 2, tweenTime).setEasePunch();
        SlimeMoveContainer();
        cannonUpgradeContainer.LeanMoveLocalY(-Screen.height,tweenTime);
        worldUpgradeContainer.LeanMoveLocalY(-Screen.height,tweenTime);
    }
    public void onClickWorldUpgrade()
    {
        PlayButtonClick();
        LeanTween.scale(worldUpgradeButton, Vector3.one * 2, tweenTime).setEasePunch();
        WorldMoveContainer();
        slimeUpgradeContainer.LeanMoveLocalY(-Screen.height,tweenTime);
        cannonUpgradeContainer.LeanMoveLocalY(-Screen.height,tweenTime);
    }

    public void PlayButtonClick()
    {
        audio.PlayOneShot(onButtonClick,volume);
    }

    public void onClickHome()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void onClickPlay()
    {
        SceneManager.LoadScene("DevScene 1");
    }
    
    public void CannonMoveContainer()
    {
      backgroundCannon.alpha = 0;
      backgroundCannon.LeanAlpha(1, tweenTime);

      cannonUpgradeContainer.localPosition = new Vector2 (0, -Screen.height);
      cannonUpgradeContainer.LeanMoveLocalY(-65,tweenTime).setEaseOutExpo();
    }
    public void SlimeMoveContainer()
    {
      slimeUpgradeContainer.localPosition = new Vector2 (0, -Screen.height);
      slimeUpgradeContainer.LeanMoveLocalY(-65,tweenTime).setEaseOutExpo();
    }
    public void WorldMoveContainer()
    {
      worldUpgradeContainer.localPosition = new Vector2 (0, -Screen.height);
      worldUpgradeContainer.LeanMoveLocalY(-65,tweenTime).setEaseOutExpo();
    }

    

    public void updateMoneyValue()
    {
        moneyText.text = "Money:" + PlayerManager.money.ToString();

    }



    #region StarSystem

    // Loop through each Upgrade and stars to play animation
    public void StarReadyAnim()
    {
        foreach (Upgrades upgrade in listOfUpgrades)
        {
            if (upgrade.name == "Cannon" && stars2[upgrade.name].Count > 0)
            {
                LeanTween.scale(stars2["Cannon"][0].gameObject, Vector3.one, 0.5f).setEaseShake();
            } else if (upgrade.name == "Extra Health" && stars2[upgrade.name].Count > 0)
            { 
                LeanTween.scale(stars2["Extra Health"][0].gameObject, Vector3.one, 0.5f).setEaseShake();
            }
        }
    }

    // Method to add the stars at the start of the scene. Takes the gridlayout to add to and the upgrade name
    private void AddStars(GridLayoutGroup grid, string upgrade)
    {
        // Get the amount of stars to Add
        for (int i = 0; i < PlayerManager.shopUpgrades[upgrade].amountOfUpgrades; i++)
            {
            
            // Create the stars and add them to the list. Set the upgrade name in the star
            GameObject instance = Instantiate(star);
            instance.transform.SetParent(grid.gameObject.transform);
            instance.GetComponent<Star>().upgradeName = PlayerManager.shopUpgrades[upgrade].name;
            list.Add(instance);

            }


        // Loop through all stars and disable them all. Do nothing if the first star
        foreach(GameObject starr in list)
        {
            if(starr == list[0])
            {
                //return;
            } 
            else
            {
                starr.GetComponent<Button>().enabled = false;
                starr.GetComponentInChildren<Image>().color = fadedColor;
            }

        }
        // Add the list to the Dictionary and then create a new list for the next upgrade/stars
        stars2[upgrade] = list;
        list = new List<GameObject>();
    }

    // Method to remove the button once clicked (Disabled)
    public void RemoveButton(string name)
    {
        // Create new list and remove the first element of the list
        List<GameObject> newStarList = stars2[name];
        newStarList.Remove(newStarList[0]);

        // If more stars are still available, enable the button on the next star 
        if (newStarList.Count > 0)
        {
            newStarList[0].GetComponent<Button>().enabled = true;
            newStarList[0].GetComponent<Image>().color = fullColor;
        }

        // Add new list to the Dictionary
        stars2[name] = newStarList;
    }


    // Method to check for what has already been bought and update the stars
    private void CheckForStarsBought()
    {
        // Loop through each upgrade and generate a new list
        foreach (Upgrades upgrade in listOfUpgrades)
        {
            
            List<GameObject> newStarList = stars2[upgrade.name];
            // if the current upgrade is greater then 0 then an upgrade has been bought
            if (PlayerManager.shopUpgrades[upgrade.name].currentUpgrade > 0)
            {
              
                for (int i = 0; i < PlayerManager.shopUpgrades[upgrade.name].currentUpgrade; i++)
                {
                    
                    // Get the 0 element of the list and make the button false so cannot click on it and then remove from the list. Do this for each upgrade bought  so if 2 stars have been bought then loop through twice and remove the first 2 from the list and disable their buttons
                    newStarList[0].GetComponent<Button>().enabled = false;
                    newStarList[0].GetComponent<Image>().color = fullColor;
                    newStarList.Remove(newStarList[0]);
                }

                // Once the bought upgrades have finished if the list is greater then 0 then get the first avaiable star and set it to be enabled.
                if (newStarList.Count > 0)
                {
                    newStarList[0].GetComponent<Button>().enabled = true;
                    newStarList[0].GetComponent<Image>().color = fullColor;
                }

                // Update the Dictionary with the new list
                stars2[upgrade.name] = newStarList;
            }

            
        }
        
    }
    // Method to set the colors of the stars to cache it
    private void StarColors()
    {
        fullColor = star.GetComponent<Image>().color;
        fullColor.a = 1;
        fadedColor = fullColor;
        fadedColor.a = 0.2f;
    }


    // Method to add all upgrades to a list
    private void AddUpgradeList()
    {
        foreach(Upgrades upgradeList in PlayerManager.shopUpgrades.Values)
        {
            listOfUpgrades.Add(upgradeList);
          
        }
    }

    // Method to Add the stars to the gui. Loops through each upgrade and adds a new list with null value to Dictionary and calls AddStars method with the gridlayout group
    private void AddStarsToGui()
    {
        foreach(Upgrades upgrade in listOfUpgrades)
        {

            if(upgrade.name == "Cannon")
            {
                stars2.Add(upgrade.name,null);
                // 0 is cannon gridlayout
                AddStars(cannonGrids[0], upgrade.name);
            }
            else if(upgrade.name == "Extra Health")
            {
                stars2.Add(upgrade.name, null);
                AddStars(slimeGrids[0], upgrade.name);
            }
        }
    }






    // Method to update the text of either buying or upgrading the upgrade
    private void UpdateUpgradeText()
    {

        foreach (Upgrades upgrade in listOfUpgrades)
        {
            // For each upgrade in player upgrades check to see if the list is greater then 0 and if its hasn't been enabled (Cost amount) if it has been enabled then (upgrade amount)
            switch (upgrade.name)
            {
                case "Cannon":
                    if (stars2[upgrade.name].Count > 0 && !PlayerManager.shopUpgrades[upgrade.name].isEnabled)
                    {
                        upgradeValueText[0].text = PlayerManager.shopUpgrades[upgrade.name].costAmount.ToString();
                    }
                    else if (stars2[upgrade.name].Count > 0 && PlayerManager.shopUpgrades[upgrade.name].isEnabled)
                    {
                        upgradeValueText[0].text = PlayerManager.shopUpgrades[upgrade.name].upgradeAmount.ToString();

                    }
                    else
                    {
                        upgradeValueText[0].text = "MAX";
                    }

                    break;
                case "Extra Health":
                    if (stars2[upgrade.name].Count > 0 && !PlayerManager.shopUpgrades[upgrade.name].isEnabled)
                    {
                        upgradeValueText[1].text = PlayerManager.shopUpgrades[upgrade.name].costAmount.ToString();
                    }
                    else if (stars2[upgrade.name].Count > 0 && PlayerManager.shopUpgrades[upgrade.name].isEnabled)
                    {
                        upgradeValueText[1].text = PlayerManager.shopUpgrades[upgrade.name].upgradeAmount.ToString();

                    }
                    else
                    {
                        upgradeValueText[1].text = "MAX";
                    }
                    break;
            }
        }

        #endregion
    }
















}
