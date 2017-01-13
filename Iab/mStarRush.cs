using UnityEngine;
using System.Collections;
using System;

public class mStarRush : MonoBehaviour {

	public delegate void AddDiamondAction();
	public static event AddDiamondAction OnAddDiamonds;

	public static bool mPremium;
	AdsController controller;

	void Awake () {
		DontDestroyOnLoad (this);
		mPremium = false;
		controller = GetComponent<AdsController> ();
		Iab.Init ();
	}

	public void ShowInterstitial(){
		controller.ShowInterstitial ();
	}

	public void ShowBanner(){
		if (controller.bannerView != null && !mStarRush.mPremium) {
			controller.bannerView.Show();
		}
	}

	public void HideBanner(){
		if (controller.bannerView != null) {
			controller.bannerView.Hide();
		}
	}

	public void mPremiumFromAndroid(string getmPremium){
		//check do we have the imPremium
		mPremium = getmPremium.Equals("true")?true:false;

		if (mPremium) { 
			HideBanner();
		}else{
			controller.RequestBanner ();
			controller.RequestInterstitial ();
		}
	}

	public void mPremiumFromiOS(bool getmPremium){
		//check do we have the imPremium
		
		//if (getmPremium) { 
			//HideBanner();
		//}else{
			controller.RequestBanner ();
			controller.RequestInterstitial ();
		//}
	}

	public void SetmPremiumToTrueFromAndroid(){
		mPremium = true;
		HideBanner ();
	}

	public void SetmPremiumToTrueFromiOS(){
		//mPremium = true;
		HideBanner ();
	}

	public void m300DiamondsFromAndroid(){
		GameData.savings.diamonds += 300;
		SaveAndUpdateUI ();
	}
	public void m700DiamondsFromAndroid(){
		GameData.savings.diamonds += 700;
		SaveAndUpdateUI ();
	}
	public void m1500DiamondsFromAndroid(){
		GameData.savings.diamonds += 1500;
		SaveAndUpdateUI ();
	}
	public void m3500DiamondsFromAndroid(){
		GameData.savings.diamonds += 3500;
		SaveAndUpdateUI ();
	}
	public void m10000DiamondsFromAndroid(){
		GameData.savings.diamonds += 10000;
		SaveAndUpdateUI ();
	}
	void SaveAndUpdateUI(){
		GameData.savings.Save ();
		OnAddDiamonds ();
	}
}
