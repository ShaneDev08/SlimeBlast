using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public GameObject cannonUpgradeContainer;
    public GameObject slimeUpgradeContainer;
    public GameObject worldUpgradeContainer;

    [Header("TweenValues")]
    [SerializeField] private float tweenTime;

    public void Start()
    {
        audio = GameObject.Find("ShopCanvas").GetComponent<AudioSource>();
    }

    public void onClickCannonUpgrade()
    {
        PlayButtonClick();
        LeanTween.scale(cannonUpgradeButton, Vector3.one * 2, tweenTime).setEasePunch();
    }

    public void onClickSlimeUpgrade()
    {
        PlayButtonClick();
        LeanTween.scale(slimeUpgradeButton, Vector3.one * 2, tweenTime).setEasePunch();
    }
    public void onClickWorldUpgrade()
    {
        PlayButtonClick();
        LeanTween.scale(worldUpgradeButton, Vector3.one * 2, tweenTime).setEasePunch();
    }

    public void PlayButtonClick()
    {
        audio.PlayOneShot(onButtonClick,volume);
    }

    public void onClickHome()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
}
