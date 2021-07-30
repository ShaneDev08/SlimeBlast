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
    public GameObject grid;
    // 0 worldUpgrade
    //1 
    public CanvasGroup backgroundWorld;
    public TextMeshProUGUI moneyText;
    [Header("ObjectReferences")]
    PlayerManager playerManager;
    Upgrades upgradeManager;
    [Header("TweenValues")]
    [SerializeField] private float tweenTime;



    public List<GameObject> stars;


    public static ShopUI instance;

    private Color fullColor;
    private Color fadedColor;



    public void Start()
    {
        StarColors();
        stars = new List<GameObject>();
        AddStars();
        CheckForStarsBought();
        instance = this;
        audio = GameObject.Find("ShopCanvas").GetComponent<AudioSource>();
        playerManager = GetComponent<PlayerManager>();
        Debug.Log(PlayerManager.shopUpgrades["Cannon"].name);

        if(stars.Count != 0)
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
       
        LeanTween.scale(stars[0].gameObject, Vector3.one, 0.5f).setEaseShake();
    }

    private void AddStars()
    {
            for (int i = 0; i < PlayerManager.shopUpgrades["Cannon"].amountOfUpgrades; i++)
            {
            GameObject instance = Instantiate(star);
            instance.transform.SetParent(grid.transform);
            stars.Add(instance);
            
            
            }

            foreach(GameObject starr in stars)
        {
            if(starr == stars[0])
            {
                //return;
            } 
            else
            {
                starr.GetComponent<Button>().enabled = false;
                starr.GetComponentInChildren<Image>().color = fadedColor;
            }

        }
    }

    public void RemoveButton()
    {
        
            stars.Remove(stars[0]);
        if (stars.Count > 0)
        {
            stars[0].GetComponent<Button>().enabled = true;
            stars[0].GetComponent<Image>().color = fullColor;
        } 

        if(stars.Count == 0)
        {
            upgradeValueText.text = "MAX";
        }
    }

    private void CheckForStarsBought()
    {

        if (PlayerManager.shopUpgrades["Cannon"].currentUpgrade > 0)
        {
            //stars[0]
            for (int i = 0; i < PlayerManager.shopUpgrades["Cannon"].currentUpgrade; i++)
            {
               
                stars[0].GetComponent<Button>().enabled = false;
                stars[0].GetComponent<Image>().color = fullColor;
                stars.Remove(stars[0]);
            }

            if (stars.Count > 0)
            {
                stars[0].GetComponent<Button>().enabled = true;
                stars[0].GetComponent<Image>().color = fullColor;
            }
            else
            {
                upgradeValueText.text = "MAX";
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




    // To get the money cost of the upgrade do the following:
    // PlayerManager.shopUpgrades["Cannon"].costAmount.ToString();
    // PlayerManager.shopUpgrades["Cannon"].upgradeAmount.ToString();











   
}
