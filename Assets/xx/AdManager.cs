using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class AdManager : MonoBehaviour
{
   
    public RewardedAd rewardedAd;
    public PASTEBINSERVER p;

    void Start()
    {
        p = GameObject.Find("ads").GetComponent<PASTEBINSERVER>();
        
      //  MobileAds.Initialize(initStatus => { });        
       RequestRewarded_admob();//Rewarded ad
    }


    public bool adClosed = false;

    public bool adFailed = false;
    public UIplayer uii;

    public void RequestRewarded_admob()
   {
        string adUnitId;
        #if UNITY_ANDROID
            adUnitId =p.rewardID;
        #elif UNITY_IPHONE
            adUnitId = "";
        #else
            adUnitId = "unexpected_platform";
        #endif

    //    this.rewardedAd = new RewardedAd(adUnitId);

      

        if (rewardedAd != null)
            rewardedAd.Destroy();

        AdRequest adRequest = new AdRequest.Builder().Build();

        RewardedAd.Load(adUnitId, adRequest, (RewardedAd ad, LoadAdError error) =>
        {
            // If the operation failed with a reason.
            if (error != null)
            {
                Debug.LogError("Rewarded ad failed to load an ad with error : " + error);
                return;
            }
            // If the operation failed for unknown reasons.
            // This is an unexpected error, please report this bug if it happens.
            if (ad == null)
            {
                Debug.LogError("Unexpected error: Rewarded load event fired with null ad and null error.");
                return;
            }

            rewardedAd = ad;
            RegisterEventHandlers(ad);

        });

    }


    private void Update()
    {
        
        if (adClosed)
        {
            this.RequestRewarded_admob();
            ///
            uii.contonigame();
           

            adClosed = false;
        }
        if (adFailed)
        {
            this.RequestRewarded_admob();
            adFailed = false;
        }
    }





     public void load_rewardedAd()
    {
        if (rewardedAd != null && rewardedAd.CanShowAd())
        {
            Debug.Log("Showing rewarded ad.");
            rewardedAd.Show((Reward reward) =>
            {
                Debug.Log(String.Format("Rewarded ad granted a reward: {0} {1}",
                                        reward.Amount,
                                        reward.Type));
            });
        }
    }


    public void RegisterEventHandlers(RewardedAd ad)
    {
        // Raised when the ad is estimated to have earned money.
        ad.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log(String.Format("Rewarded ad paid {0} {1}.",
                adValue.Value,
                adValue.CurrencyCode));
        };
        // Raised when an impression is recorded for an ad.
        ad.OnAdImpressionRecorded += () =>
        {
            Debug.Log("Rewarded ad recorded an impression.");
        };
        // Raised when a click is recorded for an ad.
        ad.OnAdClicked += () =>
        {
            Debug.Log("Rewarded ad was clicked.");
        };
        // Raised when the ad opened full screen content.
        ad.OnAdFullScreenContentOpened += () =>
        {
            Debug.Log("Rewarded ad full screen content opened.");
        };
        // Raised when the ad closed full screen content.
        ad.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Rewarded ad full screen content closed.");
            adClosed = true;
        };
        // Raised when the ad failed to open full screen content.
        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("Rewarded ad failed to open full screen content with error : "
                + error);

            adFailed = true;
           
        };



    }


}
