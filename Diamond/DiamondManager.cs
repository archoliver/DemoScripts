using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DiamondManager : MonoBehaviour {

	public GameObject restoreButton;

	public static bool isBuying;

	public GameObject FadeAllImage;
	public Animator FadeAllImageAnim;

	public Text Diamonds;

	void Start(){
		GameData.savings.Load ();
		Diamonds.text = GameData.savings.diamonds.ToString();
		mStarRush.OnAddDiamonds += UpdateDiamondText;
		#if UNITY_EDITOR
		#elif UNITY_ANDROID
		restoreButton.SetActive (false);
		#elif UNITY_IOS
		#endif
	}

	void Update(){
		#if UNITY_EDITOR
		#elif UNITY_ANDROID
		if (Application.platform == RuntimePlatform.Android) {
			if (Input.GetKey (KeyCode.Escape)) {
				GoToOtherScene("Menu");
				return;
			}
		}
		#elif UNITY_IOS
		#endif
	}

	public void GoToOtherScene(string sceneName){
		mStarRush.OnAddDiamonds -= UpdateDiamondText;
		FadeAllImage.SetActive (true);
		FadeAllImageAnim.SetTrigger ("FadeTrig");
		StartCoroutine (GoToOtherSceneDelay(sceneName));
	}
	
	IEnumerator GoToOtherSceneDelay(string sceneName){
		yield return new WaitForSeconds(Constants.sceneFadingTime);
		Application.LoadLevel (sceneName);
	}

	public void RestoreRemoveAds(){
		#if UNITY_EDITOR
		#elif UNITY_ANDROID
		#elif UNITY_IOS
		if (isBuying) return;
		isBuying = true;
		#endif

		Iab.BuyPremium ();
	}

	public void BuyDiamonds(int amount){
		#if UNITY_EDITOR
		#elif UNITY_ANDROID
		#elif UNITY_IOS
		if (isBuying) return;
		isBuying = true;
		#endif

		if (amount == 300) Iab.Buy300Diamonds();
		else if (amount == 700) Iab.Buy700Diamonds();
		else if (amount == 1500) Iab.Buy1500Diamonds();
		else if (amount == 3500) Iab.Buy3500Diamonds();
		else if (amount == 10000) Iab.Buy10000Diamonds();
	}

	void UpdateDiamondText(){
		Diamonds.text = GameData.savings.diamonds.ToString();
	}
}
