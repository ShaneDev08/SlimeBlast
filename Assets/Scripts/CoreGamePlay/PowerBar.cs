using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerBar : MonoBehaviour
{

    private Image imagePowerUp;

    private bool isPowerUp = false;
    private bool isDirectionUp = true;
    private float powerAmount = 0f;
    private float powerSpeed = 100.00f;
    // Start is called before the first frame update
    void Start()
    {
        imagePowerUp = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPowerUp)
        {
            PowerActive();
        }
    }

    private void PowerActive()
    {
        TankController.instance.isShooting = true;
        if(isDirectionUp)
        {
            powerAmount += Time.deltaTime * powerSpeed;
            if(powerAmount > 100)
            {
                isDirectionUp = false;
                powerAmount = 100.0f;
            }

        } else
        {
            powerAmount -= Time.deltaTime * powerSpeed;
            if(powerAmount < 0)
            {
                isDirectionUp = true;
                powerAmount = 0.0f;
            }
        }

        imagePowerUp.fillAmount = (1f - 0.25f) * powerAmount / 100.0f;
    }

    public void StartPowerUp()
    {
        isPowerUp = true;
        powerAmount = 0.0f;
        isDirectionUp = true;

    }

    public void EndPowerUp()
    {
        isPowerUp = false;
        UIManager.instance.powerAmount = this.powerAmount;
        
            
            EventManager.instance.Launch();

        UIManager.instance.DisableFireButton();

       

    }
}
