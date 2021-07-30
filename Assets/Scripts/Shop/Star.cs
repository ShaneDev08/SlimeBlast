using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Star : MonoBehaviour
{
    // Start is called before the first frame update

    public Button button;

    
    public void StarAnimAndBuy(string name)
    {
        if (!LeanTween.isTweening())
        {


            if (PlayerManager.BuyUpgrade(name))
            {
                LeanTween.scale(this.gameObject, Vector3.one, 0.5f).setEasePunch();
                button.enabled = false;

                ShopUI.instance.RemoveButton();
            }
        }
    }
}
