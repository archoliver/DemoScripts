using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class MenuManager : MonoBehaviour {

	mStarRush mstarRush;

	public GameObject FadeImage1;
	public GameObject FadeAllImage;
	public Animator FadeImage1Anim;
	public Animator FadeAllImageAnim;
	public static bool isScreenFading;

	public GameObject speaker;
	public GameObject speakerMute;
	public AudioSource BGM;

	public Text bestScore;
	public Text diamonds;

	void Awake(){
		GameData.savings.Load ();
		if (GameData.savings.isMute){
			//is Mute
			speaker.SetActive(false);
			speakerMute.SetActive(true);
			BGM.mute = true;
		}else{
			//not mute
			speakerMute.SetActive(false);
			speaker.SetActive(true);
			BGM.mute = false;
		}
		mstarRush = GameObject.Find ("mStarRush").GetComponent<mStarRush> ();
	}

	void Start(){
		mstarRush.ShowBanner ();
		isScreenFading = false;
		bestScore.text = GameData.savings.Best.ToString();
		diamonds.text = GameData.savings.diamonds.ToString();
	}
	
	void Update(){
		#if UNITY_EDITOR
		#elif UNITY_ANDROID
		if (Application.platform == RuntimePlatform.Android) {
			if (Input.GetKey (KeyCode.Escape)) {
				Application.Quit();
				return;
			}
		}
		#elif UNITY_IOS
		#endif
	}

	public void ToggleSound(){
		if (GameData.savings.isMute){
			//unmute
			speakerMute.SetActive(false);
			speaker.SetActive(true);
			BGM.mute = false;
			GameData.savings.isMute = false;
		}else{
			//mute
			speaker.SetActive(false);
			speakerMute.SetActive(true);
			BGM.mute = true;
			GameData.savings.isMute = true;
		}
		GameData.savings.Save();
	}

	public void GoToPlayScene(){
		FadeImage1.SetActive (true);
		FadeImage1Anim.SetTrigger ("FadeTrig");
		isScreenFading = true;
		Invoke ("GoToGameSceneDelay", Constants.sceneFadingTime);
	}

	void GoToGameSceneDelay(){
		Application.LoadLevel("Game");
	}

	public void GoToOtherScene(string sceneName){
		FadeAllImage.SetActive (true);
		FadeAllImageAnim.SetTrigger ("FadeTrig");
		isScreenFading = true;
		//hide banner ads
		mstarRush.HideBanner ();
		StartCoroutine (GoToOtherSceneDelay(sceneName));
	}

	IEnumerator GoToOtherSceneDelay(string sceneName){
		yield return new WaitForSeconds(Constants.sceneFadingTime);
		Application.LoadLevel (sceneName);
	}

	public void ShowLeaderboardUI() {
		GPGandGC.gpgAndGC.ShowLeaderboardUI ();
	}
	
	public void ShowAchievementsUI() {
		GPGandGC.gpgAndGC.ShowAchievementsUI ();
	}

	public void BuyRemoveAds(){
		#if UNITY_EDITOR
		#elif UNITY_ANDROID
		if (mStarRush.mPremium) return;
		#elif UNITY_IOS
		#endif
		Iab.BuyPremium ();
	}

}
