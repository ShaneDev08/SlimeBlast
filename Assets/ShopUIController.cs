using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopUIController : MonoBehaviour
{
    public Transform buttonHolder;
    public Transform cannonUpgradeHolder;
    public Transform slimeUprgradeHolder;
    public Transform unlockTreeHolder;
    public GameObject cannonUpgradeButton;
    public GameObject slimeUpgradeButton;
    public GameObject unlockTreeUpgradeButton;

    public AudioClip buttonClick;
    public AudioSource audio;
    public float tweenTime;
    public float volume;

    public void onClickCannonUpgrade()
    {
        PlayButtonClick();
        LeanTween.scale(cannonUpgradeButton, Vector3.one * 2, tweenTime).setEasePunch();
        CannonMoveContainer();
    }

    public void onClickSlimeUpgrade()
    {
        PlayButtonClick();
        LeanTween.scale(slimeUpgradeButton, Vector3.one * 2, tweenTime).setEasePunch();
        SlimeMoveContainer();
    }
    public void onClickUnlockTree()
    {
        PlayButtonClick();
        LeanTween.scale(unlockTreeUpgradeButton, Vector3.one * 2, tweenTime).setEasePunch();
        UnlockTreeMoveContainer();
    }

    public void onClickBack()
    {
        cannonUpgradeHolder.LeanMoveLocalY(-400,tweenTime).setEaseOutExpo();
        slimeUprgradeHolder.LeanMoveLocalY(-400,tweenTime).setEaseOutExpo();
        unlockTreeHolder.LeanMoveLocalY(-600,tweenTime).setEaseOutExpo();
        buttonHolder.LeanMoveLocalY(0,tweenTime).setEaseOutExpo();
    }


    public void CannonMoveContainer()
    {
      cannonUpgradeHolder.localPosition = new Vector2 (0, -Screen.height);
      cannonUpgradeHolder.LeanMoveLocalY(0,tweenTime).setEaseOutExpo();
      MoveUnlockButtons();
    }
    public void SlimeMoveContainer()
    {
      slimeUprgradeHolder.localPosition = new Vector2 (0, -Screen.height);
      slimeUprgradeHolder.LeanMoveLocalY(0,tweenTime).setEaseOutExpo();
      MoveUnlockButtons();
    }
    public void UnlockTreeMoveContainer()
    {
      unlockTreeHolder.localPosition = new Vector2 (0, -Screen.height);
      unlockTreeHolder.LeanMoveLocalY(0,tweenTime).setEaseOutExpo();
      MoveUnlockButtons();
    }

    public void MoveUnlockButtons()
    {
        buttonHolder.LeanMoveLocalY(-500,tweenTime).setEaseOutExpo();
    }


    public void PlayButtonClick()
    {
        audio.PlayOneShot(buttonClick,volume);
    }

    public void onClickHome()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void onClickPlay()
    {
        SceneManager.LoadScene("DevScene 1");
    }

}
