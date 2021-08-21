using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour,IUnityAdsListener
{
    public static AdsManager instance;
    public bool hasWatchedAdd;


    private void Start()
    {
        instance = this;
        Advertisement.Initialize("4218551");
        Advertisement.AddListener(this);
    }

    public void PlayRewardedAdd()
    {
        if(Advertisement.IsReady("Rewarded_Android"))
        {
            Advertisement.Show("Rewarded_Android"); 
        } 
        else
        {
            Debug.Log("Rewarded ad is not ready!");
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log("Ads are ready");
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.Log("ERROR:" + message);
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        if (!hasWatchedAdd)
        {
            Debug.Log("Video Started");
        }
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
       
            if (placementId == "Rewarded_Android" && showResult == ShowResult.Finished)
            {
                // Fire event off to shoot slime up
                Debug.Log("Ad Finished");
                EventManager.instance.OnRoundOverAdFinished();
            }
            hasWatchedAdd = true;
        
    }

    public void PlayRewardAdd()
    {
        if(!hasWatchedAdd)
        PlayRewardedAdd();
    }    
}
