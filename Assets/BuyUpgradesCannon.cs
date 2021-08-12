using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyUpgradesCannon : MonoBehaviour
{

    [SerializeField]
    private CanvasGroup upgradeBox;
    private float tweenTime = 0.5f;
    // Update is called once per frame
    private void OnEnable() 
    {
        upgradeBox.LeanAlpha(1,tweenTime);
    }

    public void CloseUpgradeScreen()
    {
        upgradeBox.LeanAlpha(0,tweenTime);
        Invoke("Deactivate",1);
    }

    private void Deactivate()
    {
        this.gameObject.SetActive(false);
    }
}
