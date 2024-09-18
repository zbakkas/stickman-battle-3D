using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
using UnityEngine.SocialPlatforms;
using GoogleMobileAds.Api;

public class AdsControl : MonoBehaviour
{
	
	
	protected AdsControl ()
	{
	}

	private static AdsControl _instance;

	InterstitialAd interstitial;

	public string AdmobID_Android, AdmobID_IOS;
	public PASTEBINSERVER p;

	public static AdsControl Instance { get { return _instance; } }

	
	void Awake ()
	{
		
		p = GameObject.Find("ads").GetComponent<PASTEBINSERVER>();
		AdmobID_Android = p.interstitialID;

		if (FindObjectsOfType (typeof(AdsControl)).Length > 1) {
			Destroy (gameObject);
			return;
		}
		
		_instance = this;
		MakeNewInterstial ();

		
		DontDestroyOnLoad (gameObject); //Already done by CBManager


	}
	

	public void HandleInterstialAdClosed (object sender, EventArgs args)
	{


		if (interstitial != null)
			interstitial.Destroy ();
		MakeNewInterstial ();
		
		
	}

	void MakeNewInterstial ()
	{

#if UNITY_ANDROID
		interstitial = new InterstitialAd (AdmobID_Android);
#endif
#if UNITY_IPHONE
		interstitial = new InterstitialAd (AdmobID_IOS);
#endif
		interstitial.OnAdClosed += HandleInterstialAdClosed;
		AdRequest request = new AdRequest.Builder ().Build ();
		interstitial.LoadAd (request);

	}


	public void showAds ()
	{
			interstitial.Show();
		

	}


	public void showAdswin()
	{
		PlayerPrefs.SetInt("shoads", PlayerPrefs.GetInt("shoads", 0) + 1);

        if (PlayerPrefs.GetInt("shoads") == 3)
        {
			PlayerPrefs.SetInt("shoads", 0);

		}
		PlayerPrefs.Save();

		if (PlayerPrefs.GetInt("shoads") == 0)
        {
			interstitial.Show();
		}
		
		

	}
	public void showAdpuse()
	{
		PlayerPrefs.SetInt("shoadspuse", PlayerPrefs.GetInt("shoadspuse", 0) + 1);

		if (PlayerPrefs.GetInt("shoadspuse") == 2)
		{
			PlayerPrefs.SetInt("shoadspuse", 0);

		}
		PlayerPrefs.Save();
		if (PlayerPrefs.GetInt("shoadspuse") == 0 )
		{
			interstitial.Show();
		}



	}



	public bool GetRewardAvailable ()
	{
		bool avaiable = false;

		return avaiable;
	}



	public void HideBannerAds ()
	{
	}

	public void ShowBannerAds ()
	{
	}

   
}

