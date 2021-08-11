using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PurchaseCannon : MonoBehaviour
{
    private bool pointerDown;
    private float pointerDownTime;
    public float requiredDownTime;
    [SerializeField]
    private Image fillImage;
    private bool isBought;

    public Button purchaseButton;
    public Button upgradeButton;

    // Update is called once per frame
    void Update()
    {
        if(pointerDown)
        {
            pointerDownTime += Time.deltaTime;
        if (pointerDownTime >= requiredDownTime)
        {
            isBought = true;
            Reset();
            DisableButton();
            EnableButton();
        }
        fillImage.fillAmount = pointerDownTime / requiredDownTime;
        }
    }

    public void OnPointerDown()
    {
        pointerDown = true;
    }

    public void DisableButton()
    {
        if (isBought)
        {
            purchaseButton.gameObject.SetActive(false);
        }
    }

    public void EnableButton()
    {
        upgradeButton.gameObject.SetActive(true);
    }

    public void OnPointerUp()
    {
        Reset();
    }

    public void Reset()
    {
        pointerDown = false;
        pointerDownTime = 0;
        fillImage.fillAmount = pointerDownTime / requiredDownTime;
    }

}
