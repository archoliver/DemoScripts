using UnityEngine;
using System.Collections;
using System;
using GoogleMobileAds;
using GoogleMobileAds.Api;

// Example script showing how to invoke the Google Mobile Ads Unity plugin.
public class AdsController : MonoBehaviour {
	
	public BannerView bannerView;
	public InterstitialAd interstitial;
	
	public void RequestBanner(){
		#if UNITY_EDITOR
		string adUnitId = "unused";
		#elif UNITY_ANDROID
		string adUnitId = "ca-app-pub-5778534746368092/6764858950";
		#elif UNITY_IPHONE
		string adUnitId = "ca-app-pub-5778534746368092/2195058559";
		#else
		string adUnitId = "unexpected_platform";
		#endif
		
		// Create a 320x50 banner at the top of the screen.
		bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);
		// Register for ad events.
		bannerView.AdLoaded += HandleAdLoaded;
		bannerView.AdFailedToLoad += HandleAdFailedToLoad;
		bannerView.AdOpened += HandleAdOpened;
		bannerView.AdClosing += HandleAdClosing;
		bannerView.AdClosed += HandleAdClosed;
		bannerView.AdLeftApplication += HandleAdLeftApplication;
		// Load a banner ad.
		bannerView.LoadAd(createAdRequest());
	}
	
	public void RequestInterstitial(){
		#if UNITY_EDITOR
		string adUnitId = "unused";
		#elif UNITY_ANDROID
		string adUnitId = "ca-app-pub-5778534746368092/8241592151";
		#elif UNITY_IPHONE
		string adUnitId = "ca-app-pub-5778534746368092/3671791754";
		#else
		string adUnitId = "unexpected_platform";
		#endif
		
		// Create an interstitial.
		interstitial = new InterstitialAd(adUnitId);
		// Register for ad events.
		interstitial.AdLoaded += HandleInterstitialLoaded;
		interstitial.AdFailedToLoad += HandleInterstitialFailedToLoad;
		interstitial.AdOpened += HandleInterstitialOpened;
		interstitial.AdClosing += HandleInterstitialClosing;
		interstitial.AdClosed += HandleInterstitialClosed;
		interstitial.AdLeftApplication += HandleInterstitialLeftApplication;
		// Load an interstitial ad.
		interstitial.LoadAd(createAdRequest());
	}
	
	// Returns an ad request with custom ad targeting.
	private AdRequest createAdRequest()
	{
		return new AdRequest.Builder()
			.AddKeyword("game")
				.TagForChildDirectedTreatment(false)
				.Build();
	}
	
	public void ShowInterstitial(){
		if (!mStarRush.mPremium) StartCoroutine(WaitAndShowInterstitial());
	}
	
	IEnumerator WaitAndShowInterstitial(){
		#if UNITY_EDITOR
		yield return new WaitForSeconds(0.1f);
		#elif (UNITY_ANDROID || UNITY_IOS)
		while(!interstitial.IsLoaded()){
			yield return new WaitForSeconds(0.5f);
		}
		interstitial.Show();
		RequestInterstitial ();
		#endif
	}
	
	#region Banner callback handlers
	
	public void HandleAdLoaded(object sender, EventArgs args){
		//print("HandleAdLoaded event received.");
	}
	
	public void HandleAdFailedToLoad(object sender, AdFailedToLoadEventArgs args){
		//print("HandleFailedToReceiveAd event received with message: " + args.Message);
	}
	
	public void HandleAdOpened(object sender, EventArgs args){
		//print("HandleAdOpened event received");
	}
	
	void HandleAdClosing(object sender, EventArgs args){
		//print("HandleAdClosing event received");
	}
	
	public void HandleAdClosed(object sender, EventArgs args){
		//print("HandleAdClosed event received");
	}
	
	public void HandleAdLeftApplication(object sender, EventArgs args){
		//print("HandleAdLeftApplication event received");
	}
	
	#endregion
	
	#region Interstitial callback handlers
	
	public void HandleInterstitialLoaded(object sender, EventArgs args){
		//print("HandleInterstitialLoaded event received.");
	}
	
	public void HandleInterstitialFailedToLoad(object sender, AdFailedToLoadEventArgs args){
		//print("HandleInterstitialFailedToLoad event received with message: " + args.Message);
	}
	
	public void HandleInterstitialOpened(object sender, EventArgs args){
		//print("HandleInterstitialOpened event received");
	}
	
	void HandleInterstitialClosing(object sender, EventArgs args){
		//print("HandleInterstitialClosing event received");
	}
	
	public void HandleInterstitialClosed(object sender, EventArgs args){
		//print("HandleInterstitialClosed event received");
	}
	
	public void HandleInterstitialLeftApplication(object sender, EventArgs args){
		//print("HandleInterstitialLeftApplication event received");
	}
	
	#endregion
}
