using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PurchaseWorldUpgrade : MonoBehaviour
{
    private bool pointerDown;
    private float pointerDownTime;
    public float requiredDownTime;
    [SerializeField]
    private Image fillImage;
    private bool isBought;

    public Button purchaseButton;
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
            ShopSelection.shopSelection.BuyWorldUpgrade();
            Reset();
        }
        fillImage.fillAmount = pointerDownTime / requiredDownTime;
        }
        if (ShopSelection.shopSelection.CheckIfWorldUpgradeBeenBought())
        {
            DisablePurchaseButton();
            //EnableUpgradeButton();
        }
        else
        {
            EnablePurchaseButton();
            //DisableUpgradeButton();
        }
    }

    public void OnPointerDown()
    {
        pointerDown = true;
    }

    public void DisablePurchaseButton()
    {
        
            purchaseButton.gameObject.SetActive(false);
        
    }

    public void EnablePurchaseButton()
    {
       
            purchaseButton.gameObject.SetActive(true);
        
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
