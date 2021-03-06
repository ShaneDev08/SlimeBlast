using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    // Make this script a singleton
    public static EventManager instance;


    public event Action LaunchSlime;
    public event Action RoundOver;


    // Makes this a singleton using instance as the var
    public void Awake()
    {
        instance = this;
    }

    public void Launch()
    {
        if(LaunchSlime != null)
        {
            LaunchSlime();
        }
    }

    public void OnRoundOverAdFinished()
    {
        if (RoundOver != null)
        {
            RoundOver();
        }
    }


}
