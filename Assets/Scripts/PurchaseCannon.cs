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

    public Transform upgradeBox;
    private float tweenTime = 0.5f;

     private void Start() 
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if(pointerDown)
        {
            pointerDownTime += Time.deltaTime;
        if (pointerDownTime >= requiredDownTime)
        {
            ShopSelection.shopSelection.BuyingCannon();
            Reset();
        }
        fillImage.fillAmount = pointerDownTime / requiredDownTime;
        }
        if (ShopSelection.shopSelection.CheckIfCannonBought())
        {
            DisablePurchaseButton();
            EnableUpgradeButton();
        } else
        {
            EnablePurchaseButton();
            DisableUpgradeButton();
        }
    }

    public void OnPointerDown()
    {
        pointerDown = true;
    }

    public void DisablePurchaseButton()
    {
        if (ShopSelection.shopSelection.CheckIfCannonBought())
        {
            purchaseButton.gameObject.SetActive(false);
        }
    }

    public void EnablePurchaseButton()
    {
        if (!ShopSelection.shopSelection.CheckIfCannonBought())
        {
            purchaseButton.gameObject.SetActive(true);
        }
    }

    public void EnableUpgradeButton()
    {
        upgradeButton.gameObject.SetActive(true);
    }
    public void DisableUpgradeButton()
    {
        upgradeButton.gameObject.SetActive(false);
    }

    public void OnPointerUp()
    {
        Reset();
    }

    public void OpenUpgradeScreen()
    {
        
        upgradeBox.LeanMoveLocalY(-25, tweenTime);
        //BuyUpgradesCannon.instance.SetCannonID(slime.id);
        //BuyUpgradesCannon.instance.CreateStars();
    }

    public void Reset()
    {
        pointerDown = false;
        pointerDownTime = 0;
        fillImage.fillAmount = pointerDownTime / requiredDownTime;
    }

}
