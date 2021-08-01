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
    public TextMeshProUGUI upgradeValueText;
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
    public GridLayoutGroup[] cannonGrids;       // 0 is Cannon Power 
    public GridLayoutGroup[] slimeGrids;        // 0 is Extra Health
    public GridLayoutGroup[] worldGrids;



    public List<GameObject> stars;
    public Dictionary<string, List<GameObject>> stars2;
    private List<Upgrades> listOfUpgrades;
    


    public static ShopUI instance;

    private Color fullColor;
    private Color fadedColor;
    private List<GameObject> list;



    public void Start()
    {
        stars2 = new Dictionary<string, List <GameObject>>();
        stars = new List<GameObject>();
        list = new List<GameObject>();
        StarColors();
        listOfUpgrades = new List<Upgrades>();
        AddUpgradeList();
        AddStarsToGui();
        
        
        //AddStars();
        //CheckForStarsBought();
        instance = this;
        audio = GameObject.Find("ShopCanvas").GetComponent<AudioSource>();
        playerManager = GetComponent<PlayerManager>();
        Debug.Log(PlayerManager.shopUpgrades["Cannon"].name);

        CheckForStarsBought();
        //if(stars.Count != 0)
        InvokeRepeating("StarReadyAnim", 3, 3);


    }

    private void Update() {
        updateMoneyValue();
        if(stars.Count > 0)
        upgradeValueText.text = PlayerManager.shopUpgrades["Cannon"].upgradeAmount.ToString();
        //CheckForBoughtItems();
        
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

    // Not sure if needed now?

    //public void StarAnim()
    //{

    //    LeanTween.scale(star, Vector3.one, 0.5f).setEasePunch();
    //}

    public void StarReadyAnim()
    {
       
        LeanTween.scale(stars2["Cannon"][0].gameObject, Vector3.one, 0.5f).setEaseShake();
        LeanTween.scale(stars2["Extra Health"][0].gameObject, Vector3.one, 0.5f).setEaseShake();
    }

    private void AddStars(GridLayoutGroup grid, string upgrade)
    {
        
        for (int i = 0; i < PlayerManager.shopUpgrades[upgrade].amountOfUpgrades; i++)
            {
            

            GameObject instance = Instantiate(star);
            instance.transform.SetParent(grid.gameObject.transform);
            instance.GetComponent<Star>().upgradeName = PlayerManager.shopUpgrades[upgrade].name;
            list.Add(instance);
            
            
            
            }

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
        
        stars2[upgrade] = list;
        list = new List<GameObject>();
    }

    public void RemoveButton(string name)
    {
        List<GameObject> newStarList = stars2[name];
        newStarList.Remove(newStarList[0]);
        if (newStarList.Count > 0)
        {
            newStarList[0].GetComponent<Button>().enabled = true;
            newStarList[0].GetComponent<Image>().color = fullColor;
        } 

        if(newStarList.Count == 0)
        {
            //upgradeValueText.text = "MAX";
        }

        stars2[name] = newStarList;
    }

    private void CheckForStarsBought()
    {
        foreach (Upgrades upgrade in listOfUpgrades)
        {
            
            List<GameObject> newStarList = stars2[upgrade.name];
            if (PlayerManager.shopUpgrades[upgrade.name].currentUpgrade > 0)
            {
                //stars[0]
                for (int i = 0; i < PlayerManager.shopUpgrades[upgrade.name].currentUpgrade; i++)
                {
                    

                    newStarList[0].GetComponent<Button>().enabled = false;
                    newStarList[0].GetComponent<Image>().color = fullColor;
                    newStarList.Remove(newStarList[0]);
                }

                if (newStarList.Count > 0)
                {
                    newStarList[0].GetComponent<Button>().enabled = true;
                    newStarList[0].GetComponent<Image>().color = fullColor;
                }
                else
                {
                    //upgradeValueText.text = "MAX";
                }
                
                stars2[upgrade.name] = newStarList;
            }

            
        }
        
    }

    private void StarColors()
    {
        fullColor = star.GetComponent<Image>().color;
        fullColor.a = 1;
        fadedColor = fullColor;
        fadedColor.a = 0.2f;
    }



    private void AddUpgradeList()
    {
        foreach(Upgrades upgradeList in PlayerManager.shopUpgrades.Values)
        {
            listOfUpgrades.Add(upgradeList);
            Debug.Log(upgradeList.name);
        }
    }

    private void AddStarsToGui()
    {
        foreach(Upgrades upgrade in listOfUpgrades)
        {

            if(upgrade.name == "Cannon")
            {
                stars2.Add(upgrade.name,null);
                AddStars(cannonGrids[0], upgrade.name);
            }
            else if(upgrade.name == "Extra Health")
            {
                stars2.Add(upgrade.name, null);
                AddStars(slimeGrids[0], upgrade.name);
            }
        }
    }




    // To get the money cost of the upgrade do the following:
    // PlayerManager.shopUpgrades["Cannon"].costAmount.ToString();
    // PlayerManager.shopUpgrades["Cannon"].upgradeAmount.ToString();











   
}
