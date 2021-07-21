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
    // 0 worldUpgrade
    //1 
    public CanvasGroup backgroundWorld;
    public TextMeshProUGUI moneyText;
    [Header("ObjectReferences")]
    PlayerManager playerManager;
    [Header("TweenValues")]
    [SerializeField] private float tweenTime;

    public void Start()
    {
        audio = GameObject.Find("ShopCanvas").GetComponent<AudioSource>();
        playerManager = GetComponent<PlayerManager>();
        
    }

    private void Update() {
        updateMoneyValue();
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
}
