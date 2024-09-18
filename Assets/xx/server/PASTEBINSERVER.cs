
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;

public class PASTEBINSERVER : MonoBehaviour
{

	public string url;
	public string bannerID, interstitialID, rewardID;

	public string addmob;
	string data;
	string reward;

    public static PASTEBINSERVER _instance;
	public static PASTEBINSERVER instance
	{
		get { return _instance; }
	}


	void Awake()
	{
        if (_instance == null)
		{
			_instance = this;
			DontDestroyOnLoad(this);
		}
		else
		{
			Destroy(this.gameObject);
		}

		StartCoroutine(players());

	}

	

	IEnumerator players()
	{
		WWW playerlink = new WWW(url);
		yield return playerlink;
		data = playerlink.text;
        //// adnetworks/////////////////////////////////////////////////////////////////////////////////
		// return Admob ids
		bannerID = getBetween(data, "banerID", "IDbaner");
		interstitialID = getBetween(data, "intrID", "IDintr");
		rewardID = getBetween(data, "REID", "IDRE");

		addmob = getBetween(data, "admobX", "Xadmob");
		//// adnetworks/////////////////////////////////////////////////////////////////////////////////

		 //MobileAds.Initialize(initStatus => { });

	}



	public static string getBetween(string strSource, string strStart, string strEnd)
	{
		int Start, End;
		if (strSource.Contains(strStart) && strSource.Contains(strEnd))
		{
			Start = strSource.IndexOf(strStart, 0) + strStart.Length;
			End = strSource.IndexOf(strEnd, Start);
			return strSource.Substring(Start, End - Start);
		}
		else
		{
			return "";
		}
	}



	





	private void CompleteMethod(bool completed, string advertiser)
	{
		Debug.Log("Closed rewarded from: " + advertiser + " -> Completed " + completed);
		if (completed == true)
		{
			//give the reward
		}
		else
		{
			//no reward
		}
	}


}
